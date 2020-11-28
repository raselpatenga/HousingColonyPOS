using AutoWrapper.Wrappers;
using Common.Dtos;
using Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.IServices
{
    public interface ICategoryService
    {
        Task<ApiResponse> GetAll(CategoryFilterDTO categoryFilter);
        Task<ApiResponse> Add(CategoryDTO categoryDTO);
        Task<ApiResponse> Update(CategoryDTO categoryDTO);
        Task<ApiResponse> GetById(string id);
        Task<ApiResponse> Search(string searchText);
        Task<ApiResponse> Delete(string Id);
        Task<ApiResponse> GroupDropdown();
    }
}
