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
        public int isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public int AccessRole { get; set; }

    }

    public class Role
    {
        public int Id { get; set; }
        public int RoleName { get; set; }
    }
}
