using System;
using System.Windows.Forms;

namespace Sloth.Core
{

    public interface IControlAdapter
    {

        Control FromHandle(IntPtr handle);

    }

}