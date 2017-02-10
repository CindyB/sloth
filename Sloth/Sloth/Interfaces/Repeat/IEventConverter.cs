using Sloth.Interfaces.Core;

namespace Sloth.Interfaces.Repeat
{

    public interface IEventConverter
    {

        ISlothEvent[] ConvertToSlothEvents(string[] lines);

    }

}
