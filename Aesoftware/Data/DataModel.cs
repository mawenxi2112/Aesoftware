using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aesoftware.Data
{
    // To-do: Use entity framework for data model in the future
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessRole { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }

        public string CreatedIP { get; set; }
        public string LastIP { get; set; }
        public string MachineGuid { get; set; }
        public int InvitedById { get; set; }
        public int InviteCount { get; set; }
    }
    
    public class Invite
    {
        public int Id { get; set; }
        public int IssueAccountId { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
    }

    public class ModuleItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsVisible { get; set; }
        public int MinimumRole { get; set; }
    }

    public class ModulePermission
    { 
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int AccountId { get; set; }
        public int IssueAccountId { get; set; }
        public int IsVisible { get; set; }
        public int CanUse { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class ModuleMenuList
    { 
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public DateTime Expiry { get; set; }
        public int IsVisible { get; set; }

        public int CanUse { get; set; }

        public ModuleMenuList(int Id, string ModuleName, DateTime Expiry, int IsVisible, int CanUse)
        {
            this.Id = Id;
            this.ModuleName = ModuleName;
            this.Expiry = Expiry;
            this.IsVisible = IsVisible;
            this.CanUse = CanUse;
        }
    }

    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }

    public class Connection
    {
        public int PollingRate { get; set; }
        public int IsClientDisabled { get; set; }
        public string AnnouncementMessage { get; set; }
        public int DefaultInviteCount { get; set; }
        public int IsHWIDLocked { get; set; }
    }
}
