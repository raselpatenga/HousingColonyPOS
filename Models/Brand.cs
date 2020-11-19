using Models.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
