using Sloth.Interfaces.Core;
using Sloth.Interfaces.Repeat;
using System;

namespace Sloth.Repeat
{
    public class EventConverter : IEventConverter
    {
        private const char CHR_LineSeparator = ';';

        public ISlothEvent[] ConvertToSlothEvents(string[] lines)
        {
            if (lines == null) throw new ArgumentNullException("lines");
            if (lines.Length == 0) throw new ArgumentException("lines");

            lines[0].Split(CHR_LineSeparator);

            return null;
        }
    }

}
