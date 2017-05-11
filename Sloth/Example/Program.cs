using Sloth.Core;
using Sloth.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ISlothListener listener = new SlothListener(new ButtonFilter());
            listener.Start();

            Application.Run(new Form1());
        }
    }
}
