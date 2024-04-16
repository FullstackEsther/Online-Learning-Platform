using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class StudentCourseEntityConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Student).WithMany(x => x.StudentCourses).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Course).WithMany(x => x.StudentCourses).HasForeignKey(x => x.CourseId);
        }
    }
}