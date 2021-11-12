using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aesoftware.Manager
{
    public class SecurityManager
    {
        private static SecurityManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;
        SecurityManager()
        {
        }
        public static SecurityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new SecurityManager();
                    }
                }

                return instance;
            }
        }

        public void Init()
        {
            if (isInit)
                return;

            isInit = true;
        }

        public void GetHWID()
        {

        }

        public void GetIP()
        {

        }
    }
}
