using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class ResultEntityConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasOne(x => x.Quiz)
            .WithOne(x => x.Result).HasForeignKey<Result>(x => x.QuizId);
            builder.HasOne(x => x.Student)
            .WithMany(x => x.Results).HasForeignKey(x => x.StudentId);
        }
    }
}