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
            builder.HasOne(x => x.Student).WithMany(x => x.Enrollments).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Course).WithMany(x => x.Enrollments).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Payment).WithOne(x => x.Enrollment).HasForeignKey<Enrollment>(x => x.PaymentId);
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
        }
    }
}