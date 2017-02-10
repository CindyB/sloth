using Sloth.Core;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Learn
{
    public class EventListener : IEventListener
    {
        private IApplicationAdapter m_ApplicationAdapter;
        private ILogger m_Logger;
        private IWinUtilities m_WinUtilities;

        public EventListener()
        {
            m_ApplicationAdapter = new ApplicationAdapter();
            m_Logger = new Logger();
            m_WinUtilities = new WinUtilities();
        }

        public void Start()
        { 
            m_ApplicationAdapter.AddEventListenerAsMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            Control control = Control.FromHandle(m.HWnd);
            if (control == null) return false;
            IntPtr windowHandle = control.FindForm().Handle;
            m_Logger.Log(m_WinUtilities.GetClassName(windowHandle) + ";" + m_WinUtilities.GetWindowText(windowHandle) + ";" + control.Name + ";" + m.ToString());

            return false;
        }

    }
}
