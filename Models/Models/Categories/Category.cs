using Models.Models;
using Models.Models.Base;
using Models.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models.Categories
{
    public class Category: BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int GroupId { get; set; }
        public Group Group { get; set; }    
        public virtual ICollection<Product> Products { get; set; }
    }
}
