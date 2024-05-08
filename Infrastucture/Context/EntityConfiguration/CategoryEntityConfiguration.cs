using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany<Course>()
            .WithOne();
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.ParentCategory).IsRequired(false);
        }
    }
}