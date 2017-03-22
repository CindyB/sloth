using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    public class MessageOnlyWindow : Form
    {
        public bool NullEventReceived { get; set; }



        public MessageOnlyWindow()
        {
            var accessHandle = this.Handle;
            NullEventReceived = false;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ChangeToMessageOnlyWindow();
        }

        private void ChangeToMessageOnlyWindow()
        {
            IntPtr HWND_MESSAGE = new IntPtr(-3);
            NativeMethods.SetParent(this.Handle, HWND_MESSAGE);
        }

        // Override
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0)
            {
                NullEventReceived = true;
            }
            base.WndProc(ref m);
        }

        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        }
    }
}