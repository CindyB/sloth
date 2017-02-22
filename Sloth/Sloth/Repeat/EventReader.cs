using Sloth.Core;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Repeat;
using System.Collections.Generic;

namespace Sloth.Repeat
{
    public class EventReader : IEventReader
    { 

        private IEventConverter m_EventConverter;
        private IFileAdapter m_FileAdapter;

        public EventReader()
        {
        m_EventConverter = new EventConverter();
        m_FileAdapter = new FileAdapter();
        }

        public IList<ISlothEvent> ReadEvents(string filePath)
        {
            return m_EventConverter.ConvertToSlothEvents(m_FileAdapter.ReadAllLines(filePath));
        }
    }

}
