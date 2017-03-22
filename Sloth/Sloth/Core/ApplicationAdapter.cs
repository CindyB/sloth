using Sloth.Interfaces.Core;
using Sloth.Interfaces.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Core
{
    public class ApplicationAdapter : IApplicationAdapter
    { 

        public FormCollection GetAllOpenForms()
        {
            return Application.OpenForms;
        }
    }

}
