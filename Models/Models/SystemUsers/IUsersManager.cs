using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.SystemUsers
{
    public interface IUsersManager
    {
        Task<User> CreateAsync(User entity);
    }
}
