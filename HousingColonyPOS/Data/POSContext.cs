using HousingColonyPOS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingColonyPOS.Data
{
    public class POSContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public POSContext(DbContextOptions options) : base(options)
        {

        }

    }
}
