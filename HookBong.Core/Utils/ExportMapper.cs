using AsmResolver.PE.Exports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core.Utils
{
    public class ExportMapper
    {
        public class ExportEntry
        {
            public CopiedProcessModule Module;
            public ExportedSymbol Symbol;
        }

        public Dictionary<IntPtr, ExportEntry> Exports = new Dictionary<IntPtr, ExportEntry>();
        public Dictionary<string, ExportEntry> ReverseExports = new Dictionary<string, ExportEntry>();

        public void AddEntry(CopiedProcessModule processModule)
        {
            var exports = processModule.Image.Exports;
            if (exports == null)
                return;

            foreach (var export in exports.Entries)
            {
                var entry = new ExportEntry
                {
                    Module = processModule,
                    Symbol = export
                };
                ReverseExports[$"{processModule.ModuleName}!{export.Name}"] = entry;
                Exports[IntPtr.Add(processModule.BaseAddress, (int)export.Address.Rva)] = entry;
            }
        }

        public bool TryGetEntry(IntPtr address, out ExportEntry value)
        {
            return Exports.TryGetValue(address, out value);
        }

        public bool TryGetEntry(string module, string name, out ExportEntry value)
        {
            return ReverseExports.TryGetValue($"{module}!{name}", out value);
        }
    }
}
