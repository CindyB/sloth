using System;

namespace Sloth.Core
{
    public class NoFilter : IFilter
    {
        public bool IsInRange(uint message)
        {
            return true;
        }
    }

}
