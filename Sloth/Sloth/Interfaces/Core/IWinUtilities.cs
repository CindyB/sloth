using System;
using System.Drawing;

namespace Sloth.Core
{
    public struct TagMsg
    {
        public IntPtr hWnd;
        public UInt32 message;
        public IntPtr wParam;
        public IntPtr lParam;
        public UInt32 time;
        public Point pt; 
    }

    public delegate int HookProc(int code, IntPtr wParam, TagMsg lParam);

    public interface IWinUtilities
    {
        int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, TagMsg lParam);

        IntPtr FindWindowsHandle(string className,string windowsName);

        IntPtr FindControlHandle(IntPtr windowsHandle, string controlName);

        string GetWindowText(IntPtr windowsHandle);

        void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent);

        int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
    }

}