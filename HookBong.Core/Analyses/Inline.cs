using AsmResolver;
using AsmResolver.PE.File.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core.Analyses
{
    public class Inline : IHookAnalysis
    {
        public List<HookAnalysisResult> AnalyzeModule(ProcessAnalyzer analyzer, CopiedProcessModule module)
        {
            var results = new List<HookAnalysisResult>();

            foreach (var section in module.ImageFile.Sections)
            {
                if (section.IsMemoryWrite || !section.IsMemoryExecute)
                    continue;

                var onDiskSection = module.ImageFileOnDisk.GetSectionContainingRva(section.Rva);

                var inMemoryData = (DataSegment)((VirtualSegment)section.Contents).PhysicalContents;
                var onDiskData = (DataSegment)((VirtualSegment)onDiskSection.Contents).PhysicalContents;

                //this is a ghetto reloc fix but whatever
                var toSkip = new Dictionary<uint, uint>();
                foreach (var reloc in module.Image.Relocations)
                    toSkip[reloc.Location.Rva] = (reloc.Type == AsmResolver.PE.Relocations.RelocationType.Dir64 ? 8U : 4U);

                //this is an even more ghetto fix for IAT entries in readonly places
                foreach (var import in module.Image.Imports)
                {
                    var dataReader = module.ImageFile.CreateReaderAtRva(import.AddressRva);

                    uint c = 0;
                    while (dataReader.ReadNativeInt(module.Image.PEKind == OptionalHeaderMagic.Pe32) != 0)
                    {
                        var offs = module.Image.PEKind == OptionalHeaderMagic.Pe32 ? 4U : 8U;
                        toSkip[import.AddressRva + c] = offs;
                        c += offs;
                    }
                }

                //isolate rvas we want
                toSkip = toSkip.Where(v => section.ContainsRva(v.Key)).ToDictionary(kvp => kvp.Key - section.Rva, kvp => kvp.Value);

                //these datatypes make me want to kill myself lol
                var diffList = new List<Tuple<uint, List<Tuple<byte, byte>>>>();
                var currDiff = Tuple.Create(0U, new List<Tuple<byte, byte>>());

                int tolerance = 0;
                for (uint i = 0; i < section.GetPhysicalSize();)
                {
                    //skip delta
                    if (toSkip.TryGetValue(i, out var j))
                    {
                        // handle overlapping cases
                        while (j != 0)
                        {
                            i++;
                            j--;

                            if (toSkip.TryGetValue(i, out var k))
                                j = Math.Max(j, k);
                        }
                        continue;
                    }

                    if (onDiskData.Data[i] != inMemoryData.Data[i])
                    {
                        tolerance = 4;
                        currDiff.Item2.Add(Tuple.Create(onDiskData.Data[i], inMemoryData.Data[i]));
                    }
                    else if (--tolerance < 0)
                        currDiff = Tuple.Create(i, new List<Tuple<byte, byte>>());
                    else
                        currDiff.Item2.Add(Tuple.Create(onDiskData.Data[i], inMemoryData.Data[i]));

                    i++;
                }

                if (currDiff.Item2.Count != 0)
                    diffList.Add(currDiff);

                foreach (var diffEntry in diffList)
                {
                    var originalSb = new StringBuilder();
                    var modifiedSb = new StringBuilder();

                    for (int i = 0; i < diffEntry.Item2.Count; i++)
                    {
                        var b = diffEntry.Item2[i];

                        if (i != 0)
                        {
                            originalSb.Append(' ');
                            modifiedSb.Append(' ');
                        }

                        originalSb.Append(b.Item1.ToString("X2"));
                        modifiedSb.Append(b.Item2.ToString("X2"));
                    }

                    var addr = module.BaseAddress.ToInt64() + section.Rva + diffEntry.Item1;

                    //todo: improve this trash ass logic
                    var set = false;
                    for (int k = 0; k < 0x20; k++)
                    {
                        if (analyzer.EMapper.TryGetEntry((IntPtr)(addr + k), out var val))
                        {
                            results.Add(new HookAnalysisResult($"{(addr):X8} ({val.Module.ModuleName}!{val.Symbol.Name}+0x{k:X})", "Inline")
                            {
                                ModuleName = module.ModuleName,
                                OriginalData = originalSb.ToString(),
                                PatchedData = modifiedSb.ToString(),
                                AdditionalInfo = ""
                            });

                            set = true;
                            break;
                        }
                    }

                    if (!set)
                    {
                        results.Add(new HookAnalysisResult($"{(addr):X8} ({section.Name}!0x{diffEntry.Item1:X})", "Inline")
                        {
                            ModuleName = module.ModuleName,
                            OriginalData = originalSb.ToString(),
                            PatchedData = modifiedSb.ToString(),
                            AdditionalInfo = ""
                        });
                    }
                }
            }

            return results;
        }

        public void Clear()
        {

        }
    }
}
