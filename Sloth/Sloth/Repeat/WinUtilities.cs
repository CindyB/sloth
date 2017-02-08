using Sloth.Interfaces;
using Sloth.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Repeat
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

        public void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent)
        {
            throw new NotImplementedException();
        }
    }

}
