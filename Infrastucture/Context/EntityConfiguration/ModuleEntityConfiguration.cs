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
            builder.HasMany(x => x.Lessons).WithOne();
            builder.HasOne<Course>().WithMany().HasForeignKey(x => x.CourseId);
            builder.HasOne<Quiz>().WithOne().HasForeignKey<Quiz>(x => x.ModuleId);
            builder.Property(x => x.Title).IsRequired(true);
            builder.HasMany(x => x.Result).WithOne().HasForeignKey(x => x.ModuleId);
        }
    }
}