using Sloth.Core;
using Sloth.Learn;
using System;
using System.Windows.Forms;

namespace Sloth.Core
{
    public class ApplicationAdapter : IApplicationAdapter
    { 

        public FormCollection AllOpenForms()
        {
            return Application.OpenForms;
        }
    }

}
