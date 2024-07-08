using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Infrastucture.Context.EntityConfiguration
{
    public class ModuleEntityConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasMany(x => x.Lessons).WithOne(x => x.Module).HasForeignKey(x => x.ModuleId);
            builder.HasOne(x => x.Course).WithMany(x => x.Modules).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Quiz).WithOne(x => x.Module).HasForeignKey<Quiz>(x => x.ModuleId);
            builder.Property(x => x.Title).IsRequired(true).HasColumnType("varchar(30)");
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
        }
    }
}