using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class QuizEntityConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasMany(x => x.Questions)
            .WithOne(x => x.Quiz).HasForeignKey(x => x.QuizId);
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(30)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.Duration).IsRequired(true);
            builder.HasMany(x => x.Result).WithOne(x => x.Quiz).HasForeignKey(x => x.QuizId);
        }
    }
}