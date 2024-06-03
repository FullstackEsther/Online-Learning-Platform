using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class UserRolesEntityConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<User>().WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            builder.HasOne<Role>().WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
        }
    }
}