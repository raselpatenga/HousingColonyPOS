using Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.SystemUsers
{
    public class UserManager : IUsersManager
    {
        private readonly IRepository<User> _repository;
        public UserManager(IRepository<User> repository)
        {
            _repository = repository;
        }
        public virtual async Task<User> CreateAsync(User entity)
        {
            Check.NotNull(entity, nameof(entity));
            Check.NotNull(entity.UserName, nameof(entity.UserName));
            await ValidateAsync(entity.UserName, entity.Id);
            return entity;
        }

        protected virtual async Task ValidateAsync(string userName, int id)
        {
            var entity = await _repository.FindAsync(x => x.UserName == userName);
            if(entity != null && entity.Id != id)
            {
                throw new DuplicateNameException("Duplicate user name: "+ userName);
            }
        }
    }
}
