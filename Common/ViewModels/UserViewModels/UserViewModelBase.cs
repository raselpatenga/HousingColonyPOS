using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ViewModels.UserViewModels
{
    public class UserViewModelBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool isActive { get; set; }
    }
}
