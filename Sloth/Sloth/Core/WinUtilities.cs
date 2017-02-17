using Sloth.Interfaces.Core;
using System;
using System.Runtime.InteropServices;
using System.Text;

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
            return FindWindow(className, windowsName);
        }

        public string GetWindowText(IntPtr windowsHandle)
        {
            StringBuilder builder = new StringBuilder(256);
            GetWindowText(windowsHandle, builder, builder.Capacity);
            return builder.ToString();
        }

        public void SendMessage(IntPtr windowsHandle, IntPtr controlHandle, ISlothEvent slothEvent)
        {
            throw new NotImplementedException();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

    }

}
