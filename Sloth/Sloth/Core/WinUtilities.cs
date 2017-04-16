using Sloth.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Sloth.Core
{
    public class WinUtilities : IWinUtilities
    {

        private List<IntPtr> childHandles;

        public IntPtr FindControlHandle(IntPtr windowsHandle, string controlName)
        {
            childHandles = new List<IntPtr>();
            if (NativeMethods.EnumChildWindows(windowsHandle, EnumChildProc, IntPtr.Zero) == 0) return IntPtr.Zero;
            foreach (IntPtr childHandle in childHandles) if (Control.FromHandle(childHandle)?.Name == controlName) return childHandle;
            return IntPtr.Zero;
        }

        public IntPtr FindWindowsHandle(string className,string windowsName)
        {
            return NativeMethods.FindWindow(className, windowsName);
        }

        public string GetWindowText(IntPtr windowsHandle)
        {
            StringBuilder builder = new StringBuilder(256);
            return NativeMethods.GetWindowText(windowsHandle, builder, builder.Capacity) != 0 ? builder.ToString() : String.Empty;
        }

        public void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent)
        {
            if (slothEvent == null) return;
            NativeMethods.SendMessage(controlHandle, slothEvent.Message,IntPtr.Zero,IntPtr.Zero);
        }


        public bool EnumChildProc(IntPtr hwndChild, ref IntPtr lParam)
        {
            childHandles.Add(hwndChild);
            return true;
        }

        public int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, TagMsg lParam)
        {
            return CallNextHookEx(hhk, nCode, wParam, lParam);
        }

        public int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId)
        {
            return SetWindowsHookEx(idHook, lpfn, hInstance, threadId);
        }

        internal static class NativeMethods
        {

            public delegate bool EnumChildCallback(IntPtr hwnd, ref IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern int EnumChildWindows(IntPtr hwnd, EnumChildCallback Proc, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

            [DllImport("user32.dll")]
            internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        }
    }

}
