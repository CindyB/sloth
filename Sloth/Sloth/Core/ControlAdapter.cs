using Sloth.Core;
using Sloth.Learn;
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
