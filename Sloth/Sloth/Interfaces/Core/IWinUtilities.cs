using System;

namespace Sloth.Core
{

    public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

    public interface IWinUtilities
    {
        int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        IntPtr FindWindowsHandle(string className,string windowsName);

        IntPtr FindControlHandle(IntPtr windowsHandle, string controlName);

        string GetWindowText(IntPtr windowsHandle);

        void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent);

        int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
    }

}