using Aesoftware.Manager;
using Aesoftware.Page;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aesoftware
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ValorantManager.Instance.SetValorantFormData("ikantembikai", "Wenxima2002");
            Application.Run(ComponentManager.Instance.Init());
            ComponentManager.Instance.CleanUp();
        }
    }
}
