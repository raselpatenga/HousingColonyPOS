using Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Products
{
    public class ProductManager:IProductManager
    {
        private readonly IRepository<Product> _repository;

        public ProductManager(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public virtual async Task<Product> CreateAsync(Product entity)
        {
            Check.NotNull(entity, nameof(entity));
            Check.NotNull(entity.ProductName, nameof(entity.ProductName));

            await ValidateAsync(entity.ProductName, entity.Id);

            return entity;
        }

        protected virtual async Task ValidateAsync(string name, int id = 0)
        {
            var entity = await _repository.FindAsync(x => x.ProductName == name);
            if (entity != null && entity.Id != id)
            {
                throw new DuplicateNameException("Duplicate category name: " + name);
            }
        }
    }
}
