using System;
using System.Windows.Forms;

namespace Sloth.Interfaces
{

    public interface IWinUtilities
    {

        IntPtr FindWindowsHandle(string className,string windowsName);

        IntPtr FindControlHandle(IntPtr windowsHandle, string controlName);

        void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent);
    }

}