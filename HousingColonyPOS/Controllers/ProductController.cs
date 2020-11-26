using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using AutoWrapper.Wrappers;
using Common.Dtos.ProductDTOs;
using Common.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HousingColonyPOS.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResponse> GetAll([FromQuery] ProductFilterDTO product)
        {
            return await _productService.GetAll(product);
        }

        [HttpPost("Add")]
        public async Task<ApiResponse> Add(ProductDTO product)
        {
            return await _productService.Add(product);
        }

    }
}