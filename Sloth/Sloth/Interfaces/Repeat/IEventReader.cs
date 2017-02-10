using Sloth.Interfaces.Core;

namespace Sloth.Interfaces.Repeat
{

    public interface IEventReader
    {

        ISlothEvent[] ReadEvents(string filePath);

    }

}
