using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class RoleEntityConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
        //    builder.HasMany<UserRole>()
        //    .WithOne();
           builder.Property(x => x.RoleName).IsRequired(true);
           builder.Property(x => x.Description).IsRequired(true);

        }
    }
}