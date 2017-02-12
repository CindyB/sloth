using Sloth.Interfaces.Learn;
using System.Windows.Forms;

namespace Sloth.Interfaces.Core
{

    public interface IApplicationAdapter
    {

        void AddEventListenerAsMessageFilter(IEventListener eventListener);

        FormCollection GetAllOpenForms();

    }

}