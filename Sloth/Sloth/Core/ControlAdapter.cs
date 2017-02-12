using Sloth.Interfaces.Core;
using Sloth.Interfaces.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Core
{
    public class ControlAdapter : IControlAdapter
    {
        public Control FromHandle(IntPtr handle)
        {
            return Control.FromHandle(handle);  
        }
    }

}
