using Common;
using Repository;
using System.Data;
using System.Threading.Tasks;

namespace Models.Models.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<Category> _repository;

        public CategoryManager(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Category> CreateAsync(Category entity)
        {
            Check.NotNull(entity, nameof(entity));
            Check.NotNull(entity.Name, nameof(entity.Name));

            await ValidateAsync(entity.Name, entity.Id);

            return entity;
        }

        protected virtual async Task ValidateAsync(string name, string id = "")
        {
            var entity = await _repository.FindAsync(x => x.Name == name);
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                throw new DuplicateNameException("Duplicate category name: " + name);
            }
        }
    }
}
