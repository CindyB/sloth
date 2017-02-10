using Sloth.Interfaces.Core;
using Sloth.Interfaces.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Core
{
    public class ApplicationAdapter : IApplicationAdapter
    { 
        public void AddEventListenerAsMessageFilter(IEventListener eventListener)
        {
            if (eventListener == null) throw new ArgumentNullException("eventListener");
            Application.AddMessageFilter(eventListener);
        }

        public FormCollection GetAllOpenForms()
        {
            return Application.OpenForms;
        }
    }

}
