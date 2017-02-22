using Sloth.Core;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Repeat;
using System;
using System.Collections.Generic;

namespace Sloth.Repeat
{
    public class EventConverter : IEventConverter
    {
        private const char CHR_LineSeparator = ';';

        public IList<ISlothEvent> ConvertToSlothEvents(string[] lines)
        {
            if (lines == null) throw new ArgumentNullException("lines");
            if (lines.Length == 0) throw new ArgumentException("lines");

            IList<ISlothEvent> slothEvents = new List<ISlothEvent>();

            foreach(string line in lines)
            {
                string[] information = lines[0].Split(CHR_LineSeparator);
                slothEvents.Add(new SlothEvent(information[0], information[1], uint.Parse(information[2])));
            }


            return slothEvents;
        }
    }

}
