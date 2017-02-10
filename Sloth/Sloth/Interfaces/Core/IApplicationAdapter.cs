using Sloth.Interfaces.Learn;

namespace Sloth.Interfaces.Core
{

    public interface IApplicationAdapter
    {

        void AddEventListenerAsMessageFilter(IEventListener eventListener);

    }

}