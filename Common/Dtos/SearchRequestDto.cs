using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOs
{
    public class SearchRequestDTO
    {
        public virtual bool IsAscending { get; set; } = false;
        public virtual string SortColumn { get; set; }
        public virtual int PageNo { get; set; } = 1;
        public string keyword  { get; set; } = "";
        public virtual string ParentId { get; set; } = "";

    }
}
