
using System;
using System.IO;
using System.Runtime.InterOpServices;

using static TimeStomp.STRUCTS;

namespace TimeStomp{

    public class API {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile( String lpFileName, EFileAccess dwDesiredAccess, EFileShare dwShareMode, 
            IntPtr securityAttrs, ECreationDisposition dwCreationDisposition, 
            EFileAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);
        [DllImport("kernel32.dll")]
        public static extern Boolean GetFileTime(
            IntPtr hFile, ref FILETIME lpCreationTime, ref FILETIME lpLastAccessTime, ref FILETIME lpLastWriteTime);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean SetFileTime(
            IntPtr hFile, ref long lpCreationTime, ref long lpLastAccessTime, ref long lpLastWriteTime);
        [DllImport("kernel32.dll")]
        public static extern Boolean CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

    }
}
