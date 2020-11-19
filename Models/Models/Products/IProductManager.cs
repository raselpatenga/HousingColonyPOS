using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Products
{
    public interface IProductManager
    {
        Task<Product> CreateAsync(Product entity);
    }
}
