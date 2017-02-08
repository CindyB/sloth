using Sloth.Interfaces;
using Sloth.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Repeat
{
    public class EventRaiser : IEventRaiser
    {
        private IWinUtilities m_WinUtilities;

        public EventRaiser()
        {
            m_WinUtilities = new WinUtilities();
        }

        public void RaiseSlothEvent(ISlothEvent eventToRaise)
        {
            IntPtr windowsHandle = m_WinUtilities.FindWindowsHandle(eventToRaise.ClassName,eventToRaise.WindowsName);

            IntPtr controlHandle  = m_WinUtilities.FindControlHandle(windowsHandle, eventToRaise.ControlName);

            m_WinUtilities.SendMessage(windowsHandle, controlHandle, eventToRaise);
        }
    }

}
