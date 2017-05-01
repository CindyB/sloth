using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Sloth.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TagMsg
    {
        public IntPtr hWnd;
        public UInt32 message;
        public IntPtr wParam;
        public IntPtr lParam;
        public UInt32 time;
        public Point pt; 
    }

    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

    public interface IWinUtilities
    {
        IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        IntPtr FindWindowsHandle(string className,string windowsName);

        IntPtr FindControlHandle(IntPtr windowsHandle, string controlName);

        string GetWindowText(IntPtr windowsHandle);

        void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent);

        IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
    }

}