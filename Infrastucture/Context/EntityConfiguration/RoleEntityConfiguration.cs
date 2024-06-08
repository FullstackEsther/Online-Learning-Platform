using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(x => x.UserRoles)
            .WithOne(x => x.Role);
            builder.Property(x => x.RoleName).IsRequired(true);
            builder.HasData(new Role("Student")
            {
                Description = "Takes a course for better Understanding",
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
            });
            builder.HasData(new Role("Instructor")
            {
                Description = "Creates and owns a course ",
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
            });
            builder.HasData(new Role("Admin")
            {
                Description = "Takes a course for better Understanding",
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
            });
        }
    }
}