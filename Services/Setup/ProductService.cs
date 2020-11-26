using AutoMapper;
using AutoWrapper.Wrappers;
using Common;
using Common.Dtos.ProductDTOs;
using Common.Dtos.UserDTOs;
using Common.Helper;
using Common.IServices;
using Common.Responses;
using Common.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using Models.Models.Products;
using Models.Models.SystemUsers;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public async Task<ApiResponse> GetAll(ProductFilterDTO productFilter)
        {
            var query = _repository.GetQueryable().
               Include(r => r.Categories).
               Include(r => r.Brand).
               WhereIf(!productFilter.SearchText.IsNullOrWhiteSpace(), x => x.ProductName.Contains(productFilter.SearchText)).
               WhereIf(productFilter.CategoryId != 0, r => r.CategoryId == productFilter.CategoryId).
               WhereIf(productFilter.BrandId != 0, r => r.BrandId == productFilter.BrandId).
               PageBy(productFilter);

            var pagedResult = await query.ToListAsync();
            Result<Product> result = new Result<Product>() { results = pagedResult, totalCount = pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<ProductViewModel>>(result);
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

        public async Task<ApiResponse> Update(ProductDTO product)
        {
            var entity = await _repository.GetAsync(product.Id);
            if(entity == null)
                return ResponseHelper.CreateErrorResponse(string.Format(Constants.NotFound, product.ProductName));

            entity.ProductName = product.ProductName;
            entity.ProductCode = product.ProductCode;
            entity.CategoryId = product.CategoryId;
            entity.BrandId = product.BrandId;
            entity.BarCode = product.BarCode;
            entity.SalePrice = product.SalePrice;
            entity.DealerPrice = product.DealerPrice;
            entity.CostPrice = product.CostPrice;
            entity.DealerCashPrice = product.DealerCashPrice;
            entity.DealerDuePrice = product.DealerDuePrice;
            entity.Type = product.Type;
            entity.Color = product.Color;
            entity.OPQty = product.OPQty;
            entity.Purchased = product.Purchased;
            entity.Sold = product.Sold;
            entity.OnHand = product.OnHand;
            entity.isActive = product.isActive;
            entity.isRow = product.isRow;

            try
            {
                entity = await _manager.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateErrorResponse(ex.Message);
            }
            await _repository.UpdateAsync(entity);
            await _work.Complete();

            return ResponseHelper.CreateUpdateSuccessResponse();
        }
    }
}
