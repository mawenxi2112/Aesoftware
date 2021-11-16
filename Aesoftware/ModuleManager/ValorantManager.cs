using Aesoftware.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValAPINet;

namespace Aesoftware.ModuleManager
{
    public class ValorantManager
    {
        private static ValorantManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;

        Auth auth = null;

        ValorantManager()
        {
        }
        public static ValorantManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new ValorantManager();
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

        public void LoadAuthWithCredentials(string username, string password, ValAPINet.Region region)
        {
            auth = null;
            auth = Auth.Login(username, password, region);

            if (string.IsNullOrEmpty(auth.AccessToken))
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Error", "Error trying to load authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Success", "Successfully loaded authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormManager.Instance.CloseForm("RiotAuthenticationForm");
            }
        }

        public void LoadAuthWithNoCredentials(ValAPINet.Region region)
        {
            auth = null;

            // Check for valorant process
            /*if (valorantProcess != running)
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Error", "Valorant has to be running!", MessageBoxButtons.OK, MessageBoxIcon.Error);*/

            if (DataManager.Instance.GetModulePermission(DataManager.Instance.GetModuleIdFromName("PremiumValorant"), AccountManager.Instance.currentAccount.Id).CanUse == 0)
            {
                FormManager.Instance.ShowMesageBoxButton("Access Error", "You do not have access to module: PremiumValorant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormManager.Instance.CloseForm("RiotAuthenticationForm");
                return;
            }

            auth = Websocket.GetAuthLocal(true);

            if (string.IsNullOrEmpty(auth.AccessToken))
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Error", "Error trying to load authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Success", "Successfully loaded authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormManager.Instance.CloseForm("RiotAuthenticationForm");
            }
        }

        public void RefreshDataOnLiteValorant()
        {
            if (!FormManager.Instance.IsFormActive("LiteValorant"))
                return;


        }

        public void RefreshDataOnPremiumValorant()
        {
            if (!FormManager.Instance.IsFormActive("PremiumValorant"))
                return;


        }
    }
}
