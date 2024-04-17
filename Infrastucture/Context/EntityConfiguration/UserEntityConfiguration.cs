using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // builder.ToTable("Users").SplitToTable("Profile", 
            // x => 
            // {
            //     x.Property(user => user.ProfilePicture);
            //     x.Property(User => User.FirstName);
            //     x.Property(user => user.LastName);
            //     x.Property(User => User.Biography);

            // }
            // );
            builder.HasOne(x => x.Role)
            .WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Password).IsRequired(true);
            
        }

    }
}