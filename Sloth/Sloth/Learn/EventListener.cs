using Sloth.Core;

namespace Sloth.Learn
{
    public class EventListener : IEventListener
    {
        private IApplicationAdapter m_ApplicationAdapter;
        private IControlAdapter m_ControlAdapter;
        private ILogger m_Logger;
        private IWinUtilities m_WinUtilities;

        public EventListener(IApplicationAdapter applicationAdapter,IControlAdapter controlAdapter, ILogger logger, IWinUtilities winUtilities)
        {
            m_ApplicationAdapter = applicationAdapter;
            m_ControlAdapter = controlAdapter;
            m_Logger = logger;
            m_WinUtilities = winUtilities;
        }

        public void Start()
        {
            //TODO
        }

    }
}
