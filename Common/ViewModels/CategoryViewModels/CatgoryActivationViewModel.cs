using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ViewModels.CategoryViewModels
{
    public class CatgoryActivationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
