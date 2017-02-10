using Sloth.Interfaces.Core;
using System;

namespace Sloth.Core
{
    public class WinUtilities : IWinUtilities
    {
        public IntPtr FindControlHandle(IntPtr windowsHandle, string controlName)
        {
            throw new NotImplementedException();
        }

        public IntPtr FindWindowsHandle(string className,string windowsName)
        {
            throw new NotImplementedException();
        }

        public string GetClassName(IntPtr windowsHandle)
        {
            throw new NotImplementedException();
        }

        public string GetWindowText(IntPtr windowsHandle)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent)
        {
            throw new NotImplementedException();
        }
    }

}
