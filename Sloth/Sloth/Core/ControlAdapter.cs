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
            //Control.FromHandle(m.HWnd);
            throw new NotImplementedException();
        }
    }

}
