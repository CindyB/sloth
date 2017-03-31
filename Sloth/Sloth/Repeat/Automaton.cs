using Sloth.Core;
using Sloth.Repeat;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sloth.Repeat
{
    public class Automaton : IAutomaton
    {

        private IEventRaiser eventRaiser;
        private IEventReader eventReader;

        public Automaton()
        {
            eventRaiser = new EventRaiser();
            eventReader = new EventReader();
        }

        public void RepeatBehavior(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException("filePath");
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path is empty","filePath");
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            IList<ISlothEvent> eventsToRaise = eventReader.ReadEvents(filePath);
            if (eventsToRaise == null) return;

            foreach (ISlothEvent eventToRaise in eventsToRaise)
            {
                eventRaiser.PublishSlothEvent(eventToRaise);
            }

        }
    }
}