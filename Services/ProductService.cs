using AutoMapper;
using AutoWrapper.Wrappers;
using Common.Dtos.ProductDTOs;
using Common.Dtos.UserDTOs;
using Common.Helper;
using Common.IServices;
using Models.Models.Products;
using Models.Models.SystemUsers;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService: IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IProductManager _manager;
        private readonly IMapper _mapper;
        private IUnitOfWork _work;

        public ProductService(IRepository<Product> repository, IProductManager manager, IMapper mapper, IUnitOfWork work)
        {
            _manager = manager;
            _repository = repository;
            _mapper = mapper;
            _work = work;
        }

        public async Task<ApiResponse> Add(ProductDTO input)
        {
            var entity = _mapper.Map<Product>(input);

            try
            {
                entity = await _manager.CreateAsync(entity);
            }
            catch(Exception ex)
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

        public Task<ApiResponse> GetAll(ProductFilterDTO productFilterDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
