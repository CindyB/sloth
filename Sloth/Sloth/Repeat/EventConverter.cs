using Sloth.Core;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Sloth.Repeat
{
    public class EventConverter : IEventConverter
    {
        private const char CHR_LineSeparator = ';';

        public IList<ISlothEvent> ConvertToSlothEvents(string[] lines)
        {
            if (lines == null) throw new ArgumentNullException("lines");
            if (lines.Length == 0) throw new ArgumentException("Array is empty","lines");

            IList<ISlothEvent> slothEvents = new List<ISlothEvent>();

            foreach(string line in lines)
            {
                string[] information = line.Split(CHR_LineSeparator);
                slothEvents.Add(new SlothEvent(information[0], information[1], uint.Parse(information[2],CultureInfo.InvariantCulture)));
            }


            return slothEvents;
        }
    }

}
