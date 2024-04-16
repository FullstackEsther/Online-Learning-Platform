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
             builder.HasMany(x => x.Modules)
             .WithOne(x =>x.Course);
             builder.HasMany(x => x.StudentCourses)
             .WithOne(x => x.Course);
             builder.HasOne(x => x.SubCategory).WithMany(x => x.Courses).HasForeignKey(x => x.SubCategoryId);
             builder.HasOne(x => x.Instructor).WithMany(x => x.Courses).HasForeignKey(x => x.InstructorId);
        }
    }
}