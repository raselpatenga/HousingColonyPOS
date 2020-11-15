using Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.SystemUsers
{
    public class User: BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public bool isActive { get; set; }
    }
}
