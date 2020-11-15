using Models.Models.SystemUsers;
using System;
using System.Collections.Generic;
using System.Text;
namespace Models.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> SystemUsers { get; set; }
    }
}
