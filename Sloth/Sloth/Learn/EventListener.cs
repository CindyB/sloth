using Sloth.Interfaces;
using System.Windows.Forms;

namespace Sloth.Learn
{
    public class EventListener : IEventListener
    {
        private IApplicationAdapter m_ApplicationAdapter;
        private ILogger m_Logger; 

        public EventListener()
        { 
            m_Logger = new Logger();
            m_ApplicationAdapter = new ApplicationAdapter();
        }

        public void Start()
        { 
            m_ApplicationAdapter.AddEventListenerAsMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            m_Logger.Log(Control.FromHandle(m.HWnd).Name + ";" + m.ToString());

            return false;
        }

    }
}
