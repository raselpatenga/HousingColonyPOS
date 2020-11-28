using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Common;
using Common.DTOs;
using Common.Helper;
using Common.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.IServices;
using Common.Dtos;

namespace API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResponse> GetAll([FromQuery] CategoryFilterDTO category)
        {
            return await _CategoryService.GetAll(category);
        }

        [HttpPost("Add")]
        public async Task<ApiResponse> Add([FromBody] CategoryDTO category)
        {
            return await _CategoryService.Add(category);
        }

        [HttpPut("Update")]
        public async Task<ApiResponse> Update([FromBody] CategoryDTO category)
        {
            return await _CategoryService.Update(category);
        }
        [HttpGet("GetById")]
        public async Task<ApiResponse> GetById(string id)
        {
            return await _CategoryService.GetById(id);
        }
    }
}
