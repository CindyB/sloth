using Sloth.Core;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Sloth.Learn
{
    public class EventListener : IEventListener
    {
        private HookProc callbackDelegate = null;
        private IControlAdapter controlAdapter = null;
        private ILogger logger = null;
        private IWinUtilities winUtilities = null;

        public EventListener(IControlAdapter controlAdapter, ILogger logger, IWinUtilities winUtilities)
        {
            this.callbackDelegate = new HookProc(HookCallback);
            this.controlAdapter = controlAdapter;
            this.logger = logger;
            this.winUtilities = winUtilities;
        }

        public void Start()
        {
            this.winUtilities.SetWindowsHookEx(7, callbackDelegate, IntPtr.Zero, Thread.CurrentThread.ManagedThreadId);
        }

        private int HookCallback(int code, IntPtr wParam, IntPtr lParam)
        {
            Control control = controlAdapter.FromHandle(lParam);

            if (control == null) return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);

            IntPtr windowHandle = control.FindForm().Handle;
            logger.Log(winUtilities.GetWindowText(windowHandle) + ";" + control.Name + ";" + wParam.ToString());
            return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

    }
}
