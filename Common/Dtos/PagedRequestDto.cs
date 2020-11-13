using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOs
{
    public class PagedRequestDTO
    {
        public virtual bool IsAscending { get; set; }
        public virtual string SortColumn { get; set; }
        public virtual int PageNo { get; set; } = 1;
        public virtual int PageSize { get; set; } = 10;

    }
}
