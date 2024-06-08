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
            builder.HasOne<Quiz>()
            .WithMany(x => x.Result).HasForeignKey(x => x.QuizId);
            builder.HasOne<Student>()
            .WithMany(x => x.Results).HasForeignKey(x => x.StudentId);
        }
    }
}