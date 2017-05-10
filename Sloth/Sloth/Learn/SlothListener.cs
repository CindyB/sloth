using Sloth.Core;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sloth.Learn
{
    public class SlothListener : ISlothListener
    {
        private HookProc callbackDelegate = null;
        private IControlAdapter controlAdapter = null;
        private IFilter filter = null;
        private ILogger logger = null;
        private IWinUtilities winUtilities = null;

        public SlothListener() : this(new ControlAdapter(), new Logger(), new WinUtilities())
        {}

        public SlothListener(IControlAdapter controlAdapter, ILogger logger, IWinUtilities winUtilities) : this ( controlAdapter,logger,winUtilities, new NoFilter())
        {}

        public SlothListener(IControlAdapter controlAdapter, ILogger logger, IWinUtilities winUtilities, IFilter filter)
        {
            this.callbackDelegate = new HookProc(HookCallback);
            this.controlAdapter = controlAdapter;
            this.logger = logger;
            this.winUtilities = winUtilities;
            this.filter = filter;
        }

        public void Start()
        {
            IntPtr t = this.winUtilities.SetWindowsHookEx(3, callbackDelegate, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        private IntPtr HookCallback(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0) return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
            TagMsg pMsg = (TagMsg)Marshal.PtrToStructure(lParam, typeof(TagMsg));
            Control control = controlAdapter.FromHandle(pMsg.hWnd);

            if (control == null) return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);

            IntPtr windowHandle = control.FindForm().Handle;
            if (filter.IsInRange(pMsg.message)) logger.Log(winUtilities.GetWindowText(windowHandle) + ";" + control.Name + ";" + pMsg.message.ToString());

            return this.winUtilities.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

    }
}
