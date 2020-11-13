using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ViewModels.CategoryViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
               
    }
}
