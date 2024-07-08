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
            builder.Property(x => x.Topic).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(x => x.TotalMinutes).IsRequired(true);
            builder.Property(x => x.File).IsRequired(true).HasColumnType("varchar(255)");
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
        }
    }
}