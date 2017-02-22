using Sloth.Interfaces.Core;
using System.Collections.Generic;

namespace Sloth.Interfaces.Repeat
{

    public interface IEventReader
    {

        IList<ISlothEvent> ReadEvents(string filePath);

    }

}
