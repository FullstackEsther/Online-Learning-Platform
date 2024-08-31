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
            builder.HasMany(x => x.UserProgresses).WithOne().HasForeignKey(x => x.CourseId);
            builder.HasMany(x => x.Modules)
            .WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
            builder.HasMany(x => x.Enrollments)
            .WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Instructor).WithMany(x => x.Courses).HasForeignKey(x => x.InstructorId);
            builder.HasOne(x => x.Category).WithMany(x => x.Courses).HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CourseCode).HasColumnType("varchar(15)");
            builder.Property(x => x.DisplayPicture).HasColumnType("varchar(255)");
            builder.Property(x => x.InstructorName).HasColumnType("varchar(30)");
            builder.Property(x => x.Title).HasColumnType("varchar(30)");
        }
    }
}