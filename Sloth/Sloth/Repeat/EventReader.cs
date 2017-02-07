﻿using Sloth.Interfaces;
using Sloth.Learn;

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

        public ISlothEvent[] ReadEvents(string filePath)
        {
            return m_EventConverter.ConvertToSlothEvents(m_FileAdapter.ReadAllLines(filePath));
        }
    }

}