using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class EnrollmentEntityConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<Student>().WithMany(x => x.Enrollments).HasForeignKey(x => x.StudentId);
            builder.HasOne<Course>().WithMany().HasForeignKey(x => x.CourseId);
        }
    }
}