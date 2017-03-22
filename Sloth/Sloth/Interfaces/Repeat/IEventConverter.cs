using Sloth.Core;
using System.Collections.Generic;

namespace Sloth.Repeat
{

    public interface IEventConverter
    {

        IList<ISlothEvent> ConvertToSlothEvents(string[] lines);

    }

}
