using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core
{
    public interface IHookAnalysis
    {
        List<HookAnalysisResult> AnalyzeModule(ProcessAnalyzer analyzer, CopiedProcessModule module);
        void Clear();
    }
}
