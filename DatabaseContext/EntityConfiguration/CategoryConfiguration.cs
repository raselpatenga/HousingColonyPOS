using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models.Categories;
using Models.Models;

namespace DatabaseContext.EntityConfiguration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name).HasMaxLength(50);

            builder.HasOne(r => r.Group)
                   .WithMany(r => r.Categories);
        }

    }
}
