using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using AutoWrapper.Wrappers;
using Common.Dtos.UserDTOs;
using Common.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HousingColonyPOS.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResponse> GetAll([FromQuery] UserFilterDto user)
        {
            return await _UserService.GetAll(user);
        }

        [HttpPost("Add")]
        public async Task<ApiResponse> Add(UserDTO user)
        {
            return await _UserService.Add(user);
        }
    }
}