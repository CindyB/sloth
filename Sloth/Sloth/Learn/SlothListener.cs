using Sloth.Core;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Sloth.Learn
{
    public class SlothListener : ISlothListener
    {
        private HookProc callbackDelegate = null;
        private IControlAdapter controlAdapter = null;
        private ILogger logger = null;
        private IWinUtilities winUtilities = null;

        public SlothListener() : this(new ControlAdapter(), new Logger(), new WinUtilities())
        {}

        public SlothListener(IControlAdapter controlAdapter, ILogger logger, IWinUtilities winUtilities)
        {
            this.callbackDelegate = new HookProc(HookCallback);
            this.controlAdapter = controlAdapter;
            this.logger = logger;
            this.winUtilities = winUtilities;
        }

        public void Start()
        {
            this.winUtilities.SetWindowsHookEx(3, callbackDelegate, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        private IntPtr HookCallback(int code, IntPtr wParam, TagMsg lParam)
        {
            if (code < 0) return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
            Control control = controlAdapter.FromHandle(lParam.hWnd);
            IntPtr windowHandle = control.FindForm().Handle;
            logger.Log(winUtilities.GetWindowText(windowHandle) + ";" + control.Name + ";" + lParam.message.ToString());
            return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

    }
}
