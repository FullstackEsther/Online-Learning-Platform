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
            builder.HasMany(x => x.Courses)
            .WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.Name).IsRequired(true).HasColumnType("varchar(30)");
            builder.Property(x => x.Description).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(x => x.ParentCategory).IsRequired(false).HasColumnType("varchar(30)");
             builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
        }
    }
}