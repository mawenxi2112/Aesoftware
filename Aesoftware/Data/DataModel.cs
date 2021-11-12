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
        public int ClaimAccountId { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
    }

    public class ModuleItem
    {
        public int Id { get; set; }
        public int Name { get; set; }
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

    public class Role
    {
        public int Id { get; set; }
        public int RoleName { get; set; }
    }
}
