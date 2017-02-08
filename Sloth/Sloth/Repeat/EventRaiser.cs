using Sloth.Interfaces;
using Sloth.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Repeat
{
    public class EventRaiser : IEventRaiser
    {
        private IApplicationAdapter m_ApplicationAdapter;

        public EventRaiser()
        {
            m_ApplicationAdapter = new ApplicationAdapter();
        }

        public void RaiseSlothEvent(ISlothEvent eventToRaise)
        {
            FormCollection openForms = m_ApplicationAdapter.GetAllOpenForms();
            //Find window, need classname and windowsname

            //find control handle GetDlgItem

            //sendmessage or senddlgitemmessage
        }
    }

}
