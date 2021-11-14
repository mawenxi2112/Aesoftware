using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aesoftware.ModuleManager
{
    public class LiteValorantManager
    {
        private static LiteValorantManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;
        LiteValorantManager()
        {
        }
        public static LiteValorantManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new LiteValorantManager();
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

        public void RefreshUI()
        {

        }
    }
}
