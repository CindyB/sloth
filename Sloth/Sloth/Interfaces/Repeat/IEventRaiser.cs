using Sloth.Interfaces.Core;

namespace Sloth.Interfaces.Repeat
{

    public interface IEventRaiser
    {

        void RaiseSlothEvent(ISlothEvent eventToRaise);

    }

}
