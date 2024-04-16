using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasOne(x => x.Quiz)
            .WithMany(x => x.Questions).HasForeignKey(x => x.QuizId);
            builder.Property(x => x.Text).IsRequired(true);
            builder.Property(x => x.CorrectAnswer).IsRequired(true);
        }
    }
}