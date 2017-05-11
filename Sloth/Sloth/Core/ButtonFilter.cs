using System;

namespace Sloth.Core
{
    public class ButtonFilter : IFilter
    {
        public bool IsInRange(uint message)
        {
            return (message >= (uint)WM.LButtonDown && message <= (uint)WM.MouseHWheel);
        }
    }

}
