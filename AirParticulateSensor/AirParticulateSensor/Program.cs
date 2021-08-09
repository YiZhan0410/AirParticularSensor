using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirParticulateSensor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create IO Handler
            var IOhandler = new XMLLocationFileReader();

            //Pass IOhandler to form via its constructor and run the form
            Application.Run(new FormIU(IOhandler));
        }
    }
}
