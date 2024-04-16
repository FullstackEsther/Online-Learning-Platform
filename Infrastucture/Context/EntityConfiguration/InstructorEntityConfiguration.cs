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
            builder.HasOne(x => x.User)
            .WithOne(x => x.Instructor).HasForeignKey<Instructor>(x => x.UserId);
            builder.HasMany(x => x.Courses)
            .WithOne(x => x.Instructor);
        } 
    }
}