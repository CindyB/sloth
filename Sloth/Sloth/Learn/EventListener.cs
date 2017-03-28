using Sloth.Core;
using System;
using System.Threading;

namespace Sloth.Learn
{
    public class EventListener : IEventListener
    {

        private IApplicationAdapter applicationAdapter = null;
        private HookProc callbackDelegate = null;
        private IControlAdapter controlAdapter = null;
        private ILogger logger = null;
        private IWinUtilities winUtilities = null;

        public EventListener(IApplicationAdapter applicationAdapter, IControlAdapter controlAdapter, ILogger logger, IWinUtilities winUtilities)
        {
            this.applicationAdapter = applicationAdapter;
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
            return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

    }
}
