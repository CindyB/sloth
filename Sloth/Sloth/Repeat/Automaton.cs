using Sloth.Core;
using Sloth.Repeat;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sloth.Repeat
{
    public class Automaton : IAutomaton
    {

        private IEventRaiser m_EventRaiser;
        private IEventReader m_EventReader;

        public Automaton()
        {
            m_EventRaiser = new EventRaiser();
            m_EventReader = new EventReader();
        }

        public void RepeatBehavior(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException("filePath");
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("filePath");
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            IList<ISlothEvent> eventsToRaise = m_EventReader.ReadEvents(filePath);
            if (eventsToRaise == null) return;

            foreach (ISlothEvent eventToRaise in eventsToRaise)
            {
                m_EventRaiser.RaiseSlothEvent(eventToRaise);
            }

        }
    }
}