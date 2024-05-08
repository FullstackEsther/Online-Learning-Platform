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
            .WithOne();
            builder.Property(x => x.Biography).IsRequired(false);
            builder.Property(x => x.ProfilePicture).IsRequired(false); 
            builder.Property(x => x.FirstName)
            .HasMaxLength(30)
            .IsRequired(true);
            builder.Property(x => x.LastName)
            .HasMaxLength(30);
        } 
    }
}