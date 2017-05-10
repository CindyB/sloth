using System;

namespace Sloth.Core
{
    public class MouseFilter : IFilter
    {
        public bool IsInRange(uint message)
        {
            return (message >= (uint)WM.NonClientMouseMove && message <= (uint)WM.NonClientXButtonDblClk) || (message >= (uint)WM.MouseFirst && message <= (uint)WM.MouseLast);
        }
    }

}
