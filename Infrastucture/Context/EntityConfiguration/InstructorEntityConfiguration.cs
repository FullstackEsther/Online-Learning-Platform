using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class InstructorEntityConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasMany(x => x.Courses)
            .WithOne(x => x.Instructor).HasForeignKey(x => x.InstructorId);
            builder.Property(x => x.Biography).IsRequired(false).HasColumnType("varchar(250)");
            builder.Property(x => x.ProfilePicture).IsRequired(false).HasColumnType("varchar(255)");
            builder.Property(x => x.FirstName)
            .HasMaxLength(30)
            .IsRequired(true).HasColumnType("varchar(30)");
            builder.Property(x => x.LastName)
            .HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
        }
    }
}