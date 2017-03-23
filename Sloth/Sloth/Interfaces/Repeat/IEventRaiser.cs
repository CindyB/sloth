using Sloth.Core;

namespace Sloth.Repeat
{

    public interface IEventRaiser
    {

        void PublishSlothEvent(ISlothEvent eventToRaise);

    }

}
