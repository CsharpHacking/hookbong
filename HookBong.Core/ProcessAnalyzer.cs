using HookBong.Core.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core
{
    public class ProcessAnalyzer
    {
        public static List<IHookAnalysis> Analyses = new List<IHookAnalysis>();

        public Process Proc;
        public ExportMapper EMapper;
        public ModuleReader MReader;
        public static void SetupAnalyses()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (var type in assembly.GetTypes())
                    if (type.IsClass && typeof(IHookAnalysis).IsAssignableFrom(type))
                        Analyses.Add((IHookAnalysis)Activator.CreateInstance(type));
        }

        public ProcessAnalyzer(Process proc)
        {
            Proc = proc;
            EMapper = new ExportMapper();
            MReader = new ModuleReader(proc);

            MReader.Read();
            foreach (var mod in MReader.ModuleList)
                EMapper.AddEntry(mod);
        }

        public List<HookAnalysisResult> AnalyzeFull()
        {
            var result = new List<HookAnalysisResult>();

            foreach (var module in MReader.ModuleList)
                foreach (var analyzer in Analyses)
                    result.AddRange(analyzer.AnalyzeModule(this, module));

            return result;
        }
    }
}
