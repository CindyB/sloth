using System;

namespace Sloth.Interfaces.Core
{

    public interface IWinUtilities
    {

        IntPtr FindWindowsHandle(string className,string windowsName);

        IntPtr FindControlHandle(IntPtr windowsHandle, string controlName);

        string GetClassName(IntPtr windowsHandle);

        string GetWindowText(IntPtr windowsHandle);

        void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent);
    }

}