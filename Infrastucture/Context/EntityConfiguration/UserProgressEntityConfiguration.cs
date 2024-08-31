using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class UserProgressEntityConfiguration : IEntityTypeConfiguration<UserProgress>
    {
        public void Configure(EntityTypeBuilder<UserProgress> builder)
        {
             builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(60)");
            builder.HasKey(x => x.Id);
        }
    }
}