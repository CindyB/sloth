using System.Windows.Forms;

namespace Sloth.Interfaces
{

    public interface IApplicationAdapter
    {

        void AddEventListenerAsMessageFilter(IEventListener eventListener);

        FormCollection GetAllOpenForms();

    }

}