
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aesoftware.Manager
{
    public class ComponentManager
    {
        private static ComponentManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;

        ComponentManager()
        {
        }
        public static ComponentManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new ComponentManager();
                    }
                }

                return instance;
            }
        }

        public Form Init()
        {
            if (isInit)
                return null;

            isInit = true;

            DatabaseManager.Instance.Init();
            AccountManager.Instance.Init();
            SecurityManager.Instance.Init();
            // The form here will be the default form on launch.
            return FormManager.Instance.Init();
        }

        // Clean up when program closes
        public void CleanUp()
        {
            DatabaseManager.Instance.Disconnect();
        }
    }
}
