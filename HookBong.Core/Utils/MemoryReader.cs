using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HookBong.Core.Utils
{
    public class MemoryReader : IDisposable
    {
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        public IntPtr ProcessHandle;

        public MemoryReader(Process process)
        {
            ProcessHandle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
            if (ProcessHandle == (IntPtr)(-1L))
                throw new AccessViolationException("Unable to create handle to process.");
        }

        public byte[] ReadMemory(IntPtr address, int size, out uint bytesRead)
        {
            var bytes = new byte[size];
            ReadProcessMemory(ProcessHandle, (IntPtr)address, bytes, size, out var read);
            bytesRead = (uint)read;
            return bytes;
        }

        public T ReadMemory<T>(IntPtr address)
        {
            var size = Marshal.SizeOf<T>();
            var read = ReadMemory(address, size, out var bytesRead);
            if (bytesRead != size)
                throw new AccessViolationException("Size read is not size of type.");
            unsafe
            {
                fixed (byte* bytes = read)
                    return Marshal.PtrToStructure<T>(new IntPtr(bytes));
            }
        }

        public void Dispose()
        {
            CloseHandle(ProcessHandle);
        }
    }
}