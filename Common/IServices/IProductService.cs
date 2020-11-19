using AutoWrapper.Wrappers;
using Common.Dtos.ProductDTOs;
using Common.Dtos.UserDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.IServices
{
    public interface IProductService
    {
        Task<ApiResponse> GetAll(ProductFilterDTO productFilterDTO);
        Task<ApiResponse> Add(ProductDTO productDTO);
        Task<ApiResponse> Update(ProductDTO product);
        Task<ApiResponse> GetById(int id);
        Task<ApiResponse> Search(string searchText);
        Task<ApiResponse> Delete(int Id);
    }
}
