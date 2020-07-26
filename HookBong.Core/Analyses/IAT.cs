using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core.Analyses
{
    public class IAT : IHookAnalysis
    {
        public List<HookAnalysisResult> AnalyzeModule(ProcessAnalyzer analyzer, CopiedProcessModule module)
        {
            var results = new List<HookAnalysisResult>();

            foreach (var importThunk in module.Image.Imports)
                foreach (var symbol in importThunk.Symbols.Where(s => s.IsImportByName))
                {
                    if (!analyzer.EMapper.TryGetEntry(importThunk.Name, symbol.Name, out var expected))
                        continue;
                    var expectedAbs = (ulong)expected.Module.BaseAddress.ToInt64() + expected.Symbol.Address.Rva;
                    if (symbol.Address != expectedAbs)
                        results.Add(new HookAnalysisResult($"{importThunk.Name}!{symbol.Name}", "IAT")
                        {
                            ModuleName = module.ModuleName,
                            OriginalData = expectedAbs.ToString("X8"),
                            PatchedData = symbol.Address.ToString("X8"),
                            AdditionalInfo = ""
                        });
                }

            return results;
        }

        public void Clear()
        {

        }
    }
}
