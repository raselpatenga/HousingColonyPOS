using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Models.Models.Categories;
using Models.Models.Products;
using Models.Models.SystemUsers;

namespace DatabaseContext
{
    public class POSContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public POSContext(DbContextOptions options) : base(options)
        {

        }

    }
}
