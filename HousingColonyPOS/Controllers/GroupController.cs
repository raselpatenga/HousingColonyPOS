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
    public class GroupController : BaseController
    {
        private readonly ICategoryService _CategoryService;
        public GroupController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
      
        [HttpPost("Dropdown")]
        public async Task<ApiResponse> Dropdown([FromQuery] SearchRequestDTO searchRequestDTO)
        {
            return await _CategoryService.GroupDropdown();
        }
    }
}
