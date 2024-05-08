using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class CoursesEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
             builder.HasMany<Module>()
             .WithOne();
             builder.HasMany<Enrollment>()
             .WithOne();
             builder.HasOne<Instructor>().WithMany(x => x.Courses).HasForeignKey(x => x.InstructorId);
             builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}