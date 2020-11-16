using AutoMapper;
using AutoWrapper.Wrappers;
using Common.Dtos.UserDTOs;
using Common.Helper;
using Common.IServices;
using Common.Responses;
using Common.ViewModels.UserViewModels;
using Microsoft.EntityFrameworkCore;
using Models.Models.SystemUsers;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Setup
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IUsersManager _manager;
        private readonly IMapper _mapper;
        private IUnitOfWork _work;

        public UserService(IRepository<User> repository, IUsersManager manager, IMapper mapper, IUnitOfWork work)
        {
            _manager = manager;
            _repository = repository;
            _mapper = mapper;
            _work = work;
        }
        public async Task<ApiResponse> Add(UserDTO input)
        {
            var entity = _mapper.Map<User>(input);

            try
            {
                entity = await _manager.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateErrorResponse(ex.Message);
            }

            await _repository.InsertAsync(entity);
            await _work.Complete();

            return ResponseHelper.CreateAddSuccessResponse();
        }

        public Task<ApiResponse> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> GetAll(UserFilterDto userFilter)
        {

            var query = _repository.GetQueryable().
                Include(r => r.Role).
                WhereIf(!userFilter.SearchText.IsNullOrWhiteSpace(), x => x.UserName.Contains(userFilter.SearchText)).
                WhereIf(userFilter.RoleId != 0, r => r.RoleId == userFilter.RoleId).
                PageBy(userFilter);

            var pagedResult = await query.ToListAsync();
            Result<User> result = new Result<User>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<UserViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }

        public Task<ApiResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
