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
            builder.HasOne<Module>()
            .WithOne(x => x.Quiz).HasForeignKey<Quiz>(x => x.ModuleId);
            builder.HasMany(x => x.Questions)
            .WithOne();
            builder.Property(x => x.Duration).IsRequired(true);
            builder.HasMany(x => x.Result).WithOne().HasForeignKey(x => x.QuizId);
        }
    }
}