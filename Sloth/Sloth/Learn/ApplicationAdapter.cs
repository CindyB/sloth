using Sloth.Interfaces;
using System;
using System.Windows.Forms;

namespace Sloth.Learn
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
