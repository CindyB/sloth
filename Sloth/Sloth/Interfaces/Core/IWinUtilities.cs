using System;

namespace Sloth.Core
{

    public interface IWinUtilities
    {

        IntPtr FindWindowsHandle(string className,string windowsName);

        IntPtr FindControlHandle(IntPtr windowsHandle, string controlName);

        string GetWindowText(IntPtr windowsHandle);

        void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent);
    }

}