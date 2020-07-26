using AsmResolver;
using AsmResolver.PE;
using AsmResolver.PE.File;
using AsmResolver.PE.File.Headers;
using HookBong.Core.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core
{
    public class CopiedProcessModule
    {
        public string ModuleName;
        public IntPtr BaseAddress;

        public PEFile ImageFile;
        public IPEImage Image;

        public PEFile ImageFileOnDisk;
        public IPEImage ImageOnDisk;

        public CopiedProcessModule(Process process, IntPtr baseAddress, int size)
        {
            BaseAddress = baseAddress;
            using (var memoryReader = new MemoryReader(process))
            {
                var copiedBytes = memoryReader.ReadMemory(baseAddress, size, out var bytesRead);
                if (bytesRead != size)
                    throw new AccessViolationException("Could not copy entire module into memory.");
                var reader = new ByteArrayReader(copiedBytes);

                // DOS header.
                var dosHeader = DosHeader.FromReader(reader);
                reader.FileOffset = dosHeader.NextHeaderOffset;

                uint signature = reader.ReadUInt32();
                if (signature != 0x4550) //PE\0\0
                    throw new BadImageFormatException();

                // Read NT headers.
                var peFile = new PEFile(
                    dosHeader,
                    FileHeader.FromReader(reader),
                    OptionalHeader.FromReader(reader));
                ImageFile = peFile;

                // Section headers.
                reader.FileOffset = peFile.OptionalHeader.FileOffset + peFile.FileHeader.SizeOfOptionalHeader;
                for (int i = 0; i < peFile.FileHeader.NumberOfSections; i++)
                {
                    var header = SectionHeader.FromReader(reader);
                    header.PointerToRawData = header.VirtualAddress;
                    header.SizeOfRawData = header.VirtualSize;

                    var contentsReader = reader.Fork(header.PointerToRawData, header.VirtualSize);
                    var contents = DataSegment.FromReader(contentsReader);
                    contents.UpdateOffsets(header.PointerToRawData, header.VirtualAddress);

                    peFile.Sections.Add(new PESection(header, new VirtualSegment(contents, header.VirtualSize)));
                }

                Image = PEImage.FromFile(peFile);
            }
        }
    }
}
