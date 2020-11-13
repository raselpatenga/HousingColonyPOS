using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOs
{
    public class CategoryFilterDTO : PagedRequestDTO
    {
        public int GroupId { get; set; }
        public string SearchText { get; set; }
    }
}
