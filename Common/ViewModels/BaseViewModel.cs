using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class BaseViewModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
