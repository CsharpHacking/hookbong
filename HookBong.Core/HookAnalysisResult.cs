using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core
{
    public class HookAnalysisResult
    {
        public string Location;
        public string ModuleName;
        public string Type;
        public string OriginalData;
        public string PatchedData;
        public string AdditionalInfo;

        public HookAnalysisResult(string location, string type)
        {
            Location = location;
            Type = type;
        }
    }
}
