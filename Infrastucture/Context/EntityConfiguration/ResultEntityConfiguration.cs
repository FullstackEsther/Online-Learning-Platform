using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class ResultEntityConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasOne(x => x.Quiz)
            .WithMany(x => x.Result).HasForeignKey(x => x.QuizId);
            builder.HasOne(x => x.Student)
            .WithMany(x => x.Results).HasForeignKey(x => x.StudentId);
            builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
            builder.Property(u => u.QuestionAnswers)
            .HasConversion(new JsonValueConverter<QuestionAnswer>())
            .HasColumnType("json");
        }
    }
}