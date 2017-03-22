using Sloth.Core;
using System.Collections.Generic;

namespace Sloth.Repeat
{

    public interface IEventReader
    {

        IList<ISlothEvent> ReadEvents(string filePath);

    }

}
