using System;

namespace Sloth.Core
{
    public class KeyboardFilter : IFilter
    {
        public bool IsInRange(uint message)
        {
            return (message >= (uint)WM.KeyFirst && message <= (uint)WM.KeyLast);
        }
    }

}
