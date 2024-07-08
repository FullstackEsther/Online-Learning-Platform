using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(x => x.Enrollments)
            .WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            builder.HasMany(x => x.Results)
            .WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            builder.Property(x => x.ProfilePicture).IsRequired(false).HasColumnType("varchar(255)");
            builder.Property(x => x.Biography).IsRequired(false).HasColumnType("varchar(250)"); 
            builder.Property(x => x.FirstName)
            .HasMaxLength(30).HasColumnType("varchar(30)")
            .IsRequired(true);
            builder.Property(x => x.LastName).HasColumnType("varchar(30)")
            .HasMaxLength(30).IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
        }

    }
}