using AutoWrapper.Wrappers;
using Common.Dtos;
using Common.Dtos.UserDTOs;
using Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.IServices
{
    public interface IUserService
    {
        Task<ApiResponse> GetAll(UserFilterDto userFilterDto);
        Task<ApiResponse> Add(UserDTO userDTO);
        Task<ApiResponse> Update(UserDTO userDTO);
        Task<ApiResponse> GetById(int id);
        Task<ApiResponse> Search(string searchText);
        Task<ApiResponse> Delete(int Id);
    }
}
