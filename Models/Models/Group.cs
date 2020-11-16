using Models.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
