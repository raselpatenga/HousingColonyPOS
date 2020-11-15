using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.Categories;
using Models.Models.SystemUsers;

namespace DatabaseContext
{
    public class POSContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public POSContext(DbContextOptions options) : base(options)
        {

        }

    }
}
