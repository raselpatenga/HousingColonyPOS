using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos.ProductDTOs
{
    public class ProductFilterDTO:PagedRequestDTO
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string SearchText { get; set; }
    }
}
