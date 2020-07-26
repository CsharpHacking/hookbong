using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core.Analyses
{
    public class EAT : IHookAnalysis
    {
        public List<HookAnalysisResult> AnalyzeModule(ProcessAnalyzer analyzer, CopiedProcessModule module)
        {
            var results = new List<HookAnalysisResult>();
            if (module.Image.Exports == null || module.ImageOnDisk.Exports == null)
                return results;

            for (int i = 0; i < module.Image.Exports.Entries.Count; i++)
            {
                var export = module.Image.Exports.Entries[i];
                if (module.ImageOnDisk.Exports.Entries.Count <= i)
                    break;

                var exportOnDisk = module.ImageOnDisk.Exports.Entries[i];
                if (exportOnDisk.Address.Rva != export.Address.Rva)
                {
                    results.Add(new HookAnalysisResult($"{export.Name}", "EAT")
                    {
                        ModuleName = module.ModuleName,
                        OriginalData = $"[RVA] - {exportOnDisk.Address.Rva:X8}",
                        PatchedData = $"[RVA] - {export.Address.Rva:X8}",
                        AdditionalInfo = ""
                    });
                }
            }

            return results;
        }

        public void Clear()
        {

        }
    }
}
