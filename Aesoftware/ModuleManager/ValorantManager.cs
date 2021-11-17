using Aesoftware.Data;
using Aesoftware.Manager;
using Aesoftware.ModulePage;
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
        Content content = null;

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
            {
                SecurityManager.Instance.AddAuditLog("RiotAuthenticationForm", AuditAction.LITEVALORANT_AUTH_FAILED, AccountManager.Instance.currentAccount.Id, "Credentials auth failed", username + ":" + password + ":" + region);
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Error", "Error trying to load authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SecurityManager.Instance.AddAuditLog("RiotAuthenticationForm", AuditAction.LITEVALORANT_AUTH_SUCCESS, AccountManager.Instance.currentAccount.Id, "Credentials auth success", username + ":" + password + ":" + region);
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

            ModuleMenuList moduleMenuList = FormManager.Instance.moduleMenuItemList.Where(moduleMenuItem => moduleMenuItem.ModuleName == "PremiumValorant").FirstOrDefault();

            if (moduleMenuList.CanUse == 0)
            {
                SecurityManager.Instance.AddAuditLog("RiotAuthenticationForm", AuditAction.LITEVALORANT_AUTH_FAILED, AccountManager.Instance.currentAccount.Id, "No access to premium valorant", region.ToString());
                FormManager.Instance.ShowMesageBoxButton("Access Error", "You do not have access to module: PremiumValorant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            auth = Websocket.GetAuthLocal(true);

            if (string.IsNullOrEmpty(auth.AccessToken))
            {
                SecurityManager.Instance.AddAuditLog("RiotAuthenticationForm", AuditAction.LITEVALORANT_AUTH_FAILED, AccountManager.Instance.currentAccount.Id, "No credentials auth failed", region.ToString());
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Error", "Error trying to load authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SecurityManager.Instance.AddAuditLog("RiotAuthenticationForm", AuditAction.LITEVALORANT_AUTH_SUCCESS, AccountManager.Instance.currentAccount.Id, "No credentials auth success", region.ToString());
                FormManager.Instance.ShowMesageBoxButton("Riot Authentication Success", "Successfully loaded authentication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormManager.Instance.CloseForm("RiotAuthenticationForm");
            }
        }

        public void RefreshDataOnLiteValorant()
        {
            if (!FormManager.Instance.IsFormActive("LiteValorant"))
                return;

            if (content == null)
                content = Content.GetContentWrappedAPI();

            LiteValorant liteValorant = FormManager.Instance.GetForm("LiteValorant") as LiteValorant;

            if (liteValorant == null || auth == null)
                return;

            liteValorant.infoListView.Items.Clear();
            liteValorant.competitiveListView.Items.Clear();
            liteValorant.storeListView.Items.Clear();
            // To-do: Find a more dynamic way to add data, but I guess not is fine too :/
            // Filling info field
            Username username = Username.GetUsername(auth);
            Balance balance = Balance.GetBalance(auth);
            AccountXP accountXP = AccountXP.GetOffers(auth);
            MMR mmr = MMR.GetMMR(auth);
            Storefront storefront = Storefront.GetOffers(auth);

            liteValorant.infoListView.Items.Add(new ListViewItem(new string[] { "Riot ID:", username.GameName + "#" + username.TagLine}));
            liteValorant.infoListView.Items.Add(new ListViewItem(new string[] { "Valorant Points:", balance.ValorantPoints.ToString()}));
            liteValorant.infoListView.Items.Add(new ListViewItem(new string[] { "Radianite Points:", balance.RadianitePoints.ToString()}));
            liteValorant.infoListView.Items.Add(new ListViewItem(new string[] { "Level:", accountXP.Progress.Level.ToString()}));

            liteValorant.competitiveListView.Items.Add(new ListViewItem(new string[] { "Rank:", Ranks.GetRankFormatted(mmr.Rank) }));
            liteValorant.competitiveListView.Items.Add(new ListViewItem(new string[] { "Rank Rating:", mmr.RankedRating.ToString() }));
            liteValorant.competitiveListView.Items.Add(new ListViewItem(new string[] { "Number Of Wins:", mmr.NumberOfWins.ToString() }));
            liteValorant.competitiveListView.Items.Add(new ListViewItem(new string[] { "Number Of Games Played:", mmr.NumberOfGames.ToString() }));
            liteValorant.competitiveListView.Items.Add(new ListViewItem(new string[] { "Leaderboard Rank:", mmr.LeaderboardRank.ToString() }));

            foreach (string itemOffer in storefront.SkinsPanelLayout.SingleItemOffers)
            {
                Content.SkinLevel skinLevel = content.SkinLevels.Where(skin => skin.ID.ToUpper() == itemOffer.ToUpper()).FirstOrDefault();
                liteValorant.storeListView.Items.Add(new ListViewItem(new string[] { skinLevel.Name }));
            }
        }

        public void RefreshDataOnPremiumValorant()
        {
            if (!FormManager.Instance.IsFormActive("PremiumValorant"))
                return;


        }
    }
}
