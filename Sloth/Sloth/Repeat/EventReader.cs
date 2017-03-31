using Sloth.Core;
using System.Collections.Generic;

namespace Sloth.Repeat
{
    public class EventReader : IEventReader
    { 

        private IEventConverter eventConverter;
        private IFileAdapter fileAdapter;

        public EventReader()
        {
        eventConverter = new EventConverter();
        fileAdapter = new FileAdapter();
        }

        public IList<ISlothEvent> ReadEvents(string filePath)
        {
            return eventConverter.ConvertToSlothEvents(fileAdapter.ReadAllLines(filePath));
        }
    }

}
