using System;
using System.Windows.Forms;

namespace Sloth.Interfaces.Core
{

    public interface IControlAdapter
    {

        Control FromHandle(IntPtr handle);

    }

}