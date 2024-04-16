using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class LessonEntityConfiguration : IEntityTypeConfiguration<Lesson>
    {
         public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasOne(x => x.Module)
            .WithMany(x => x.Lessons).HasForeignKey(x => x.ModuleId);
            builder.Property(x => x.Topic).IsRequired(true);
            builder.Property(x => x.TotalTime).IsRequired(true);
            builder.Property(x => x.File).IsRequired(true);
        }
    }
}