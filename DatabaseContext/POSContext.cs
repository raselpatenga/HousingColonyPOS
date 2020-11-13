using Microsoft.EntityFrameworkCore;
using Models.Models.Categories;

namespace DatabaseContext
{
    public class POSContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public POSContext(DbContextOptions options) : base(options)
        {

        }

    }
}
