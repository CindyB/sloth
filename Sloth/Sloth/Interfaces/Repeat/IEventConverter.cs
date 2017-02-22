using Sloth.Interfaces.Core;
using System.Collections.Generic;

namespace Sloth.Interfaces.Repeat
{

    public interface IEventConverter
    {

        IList<ISlothEvent> ConvertToSlothEvents(string[] lines);

    }

}
