using Sloth.Core;

namespace Sloth.Repeat
{

    public interface IEventRaiser
    {

        void RaiseSlothEvent(ISlothEvent eventToRaise);

    }

}
