using Sloth.Core;
using System;

namespace Sloth.Repeat
{
    public class EventRaiser : IEventRaiser
    {
        private IWinUtilities winUtilities;

        public EventRaiser()
        {
            winUtilities = new WinUtilities();
        }

        public void PublishSlothEvent(ISlothEvent eventToRaise)
        {
            if (eventToRaise == null) throw new ArgumentNullException("eventToRaise");
            IntPtr windowsHandle = winUtilities.FindWindowsHandle(null,eventToRaise.WindowsName);

            IntPtr controlHandle  = winUtilities.FindControlHandle(windowsHandle, eventToRaise.ControlName);

            winUtilities.SendMessage(windowsHandle, controlHandle, eventToRaise);
        }
    }

}
