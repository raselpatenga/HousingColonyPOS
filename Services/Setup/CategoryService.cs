using AutoMapper;
using AutoWrapper.Wrappers;
using Common;
using Common.Dtos;
using Common.DTOs;
using Common.Helper;
using Common.IServices;
using Common.Responses;
using Common.ViewModels.CategoryViewModels;
using Microsoft.EntityFrameworkCore;
using Models.Models.Categories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly ICategoryManager _manager;
        private readonly IMapper _mapper;
        private IUnitOfWork _work;

        public CategoryService(IRepository<Category> repository, ICategoryManager manager, IMapper mapper, IUnitOfWork work)
        {
            _manager = manager;
            _repository = repository;
            _mapper = mapper;
            _work = work;
        }

        public async Task<ApiResponse> GetAll(CategoryFilterDTO categoryFilter)
        {
            //if (categoryFilter.GroupId == 0)
            //{
            //    return ResponseHelper.CreateErrorResponse("Hub is required");
            //}
            var pagedResult = await _repository.WithDetails(x => x.Name).
                WhereIf(!categoryFilter.SearchText.IsNullOrWhiteSpace(), x => x.Name.Contains(categoryFilter.SearchText)).
               
                PageBy(categoryFilter).ToListAsync();

            Result<Category> result = new Result<Category>() { results = pagedResult, totalCount = await _repository.GetCountAsync(r => r.GroupId == categoryFilter.GroupId) };

            Result<CategoryViewModel> resultCategoryViewModel = new Result<CategoryViewModel>();

            resultCategoryViewModel.totalCount = result.totalCount;

            List<CategoryViewModel> lstCategoryViewModel = new List<CategoryViewModel>();
            CategoryViewModel categoryViewModel;
            foreach (var r in result.results)
            {
                categoryViewModel = new CategoryViewModel();
                categoryViewModel.CreatedDate = r.CreatedDate;
                categoryViewModel.GroupId = r.GroupId;
                categoryViewModel.Id = r.Id;
                categoryViewModel.Name = r.Name;
                categoryViewModel.UpdatedDate = r.UpdatedDate;
                lstCategoryViewModel.Add(categoryViewModel);

            }
            resultCategoryViewModel.results = lstCategoryViewModel;
            return ResponseHelper.CreateGetSuccessResponse(resultCategoryViewModel);
        }

        public async Task<ApiResponse> Add(CategoryDTO input)
        {
            var entity = _mapper.Map<Category>(input);

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

        public async Task<ApiResponse> Update(CategoryDTO input)
        {
            var entity = await _repository.GetAsync(input.Id);
            if (entity == null)
                return ResponseHelper.CreateErrorResponse(string.Format(Constants.NotFound, input.Name));

            entity.Name = input.Name;

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


        public async Task<ApiResponse> GetById(int id)
        {
            var smartFolder = await _repository.FindAsync(r => r.Id == id, true, default(CancellationToken));

            if (smartFolder == null)
                return ResponseHelper.CreateGetSuccessResponse(string.Format(Constants.NotFound, "Smart Folder"));

            var CategoryViewModel = _mapper.Map<CategoryViewModel>(smartFolder);

            return ResponseHelper.CreateGetSuccessResponse(CategoryViewModel);
        }

        public async Task<ApiResponse> Search(string searchText)
        {
            var result = await _repository.Find(r => r.Name.Contains(searchText));
            var lstCategoryViewModel = _mapper.Map<List<CategoryViewModel>>(result);

            return ResponseHelper.CreateGetSuccessResponse(lstCategoryViewModel);
        }

        public Task<ApiResponse> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
