using AsmResolver.PE;
using AsmResolver.PE.File;
using AsmResolver.PE.File.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core.Utils
{
    public class ModuleReader
    {
        private Process _process;

        public List<CopiedProcessModule> ModuleList = new List<CopiedProcessModule>();

        public ModuleReader(Process process)
        {
            _process = process;
        }

        public void Read()
        {
            try
            {
                foreach (ProcessModule module in _process.Modules)
                {
                    try
                    {
                        var fileOnDisk = PEFile.FromFile(module.FileName);
                        var imageOnDisk = PEImage.FromFile(fileOnDisk);
                        if (!imageOnDisk.Characteristics.HasFlag(Characteristics.Image))
                            continue;

                        ModuleList.Add(new CopiedProcessModule(_process, module.BaseAddress, module.ModuleMemorySize)
                        {
                            ModuleName = module.ModuleName,
                            ImageFileOnDisk = fileOnDisk,
                            ImageOnDisk = imageOnDisk
                        });
                    }
                    catch (AccessViolationException)
                    {
                        //do nothing, could be something malicious
                    }
                }
            }
            catch (Win32Exception)
            {
                //do nothing again, we probably just don't have access. TODO: log this somehow!
            }
        }
    }
}
