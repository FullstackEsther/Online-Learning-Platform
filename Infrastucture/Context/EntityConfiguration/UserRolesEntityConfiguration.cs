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
            builder.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
            builder.HasData(new UserRole()
            {
                RoleId = Guid.Parse("95431a3c-63cf-480d-9350-7a8f92f15c4f"),
                UserId = Guid.Parse("e8374987-be9c-4099-91a6-a024754b7703"),
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now
            });
        }
    }
}