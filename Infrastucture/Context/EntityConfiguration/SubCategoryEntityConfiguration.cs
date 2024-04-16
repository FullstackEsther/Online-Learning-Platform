using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class SubCategoryEntityConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasOne(x => x.Category)
            .WithMany(x => x.SubCategories)
            .HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.Courses)
            .WithOne(x => x.SubCategory);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}