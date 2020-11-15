using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos.UserDTOs
{
    public class UserFilterDto : PagedRequestDTO
    {
        public int RoleId { get; set; }
        public string SearchText { get; set; }
    }
}
