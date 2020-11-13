using System.Threading.Tasks;

namespace Models.Models.Categories
{
    public interface ICategoryManager
    {
        Task<Category> CreateAsync(Category entity);
    }
}