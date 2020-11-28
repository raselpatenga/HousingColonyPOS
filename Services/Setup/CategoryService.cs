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
using Models.Models;
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

        public CategoryService(IRepository<Category> repository,  ICategoryManager manager, IMapper mapper, IUnitOfWork work)
        {
            _manager = manager;
            _repository = repository;
            _mapper = mapper;
            _work = work;
        }

        public async Task<ApiResponse> GetAll(CategoryFilterDTO categoryFilter)
        {
            var query = _repository.GetQueryable().
                Include(r => r.Group).
                WhereIf(!categoryFilter.SearchText.IsNullOrWhiteSpace(), x => x.Name.Contains(categoryFilter.SearchText)).
                WhereIf(categoryFilter.GroupId != 0, r => r.GroupId == categoryFilter.GroupId).
                PageBy(categoryFilter);

            var pagedResult = await query.ToListAsync();
            Result<Category> result = new Result<Category>() { results = pagedResult, totalCount =  pagedResult.LongCount() };
            var resultViewModel = _mapper.Map<Result<CategoryViewModel>>(result);
            return ResponseHelper.CreateGetSuccessResponse(resultViewModel);
        }

        public async Task<ApiResponse> Add(CategoryDTO input)
        {
            var entity = _mapper.Map<Category>(input);
            entity.Id = Guid.NewGuid().ToString();
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
            var entity = await _repository.FirstOrDefault(x=>x.Id == input.Id);
            if (entity == null)
                return ResponseHelper.CreateErrorResponse(string.Format(Constants.NotFound, input.Name));

            entity.Name = input.Name;
            entity.GroupId = input.GroupId;

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


        public async Task<ApiResponse> GetById(string id)
        {
            var smartFolder = await _repository.FirstOrDefault(x => x.Id == id);

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

        public Task<ApiResponse> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> GroupDropdown()
        {
            var groups = new List<Select>();
            groups.Add(new Select { Id = 1, Text = "group-1" });
            return ResponseHelper.CreateGetSuccessResponse(groups);
        }
    }
}
