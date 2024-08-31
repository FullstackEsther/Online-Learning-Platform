using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Context.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Courses)
            .WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.Name).IsRequired(true).HasColumnType("varchar(30)");
            builder.Property(x => x.Description).IsRequired(true).HasColumnType("varchar(200)");
            builder.Property(x => x.ParentCategory).IsRequired(false).HasColumnType("varchar(30)");
             builder.Property(x => x.CreatedOn).HasColumnType("datetime(0)");
            builder.Property(x => x.CreatedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedBy).HasColumnType("varchar(60)");
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime(0)");
            builder.HasData(new Category("Profesional Development","Encompasses activities aimed at improving one's skills, knowledge, and career prospects"){
                 CreatedBy ="Admin",
                  CreatedOn = DateTime.Now
            });
            builder.HasData(new Category("Art and Design","Encompass the creative expression and application of visual and artistic skills"){
                 CreatedBy ="Admin",
                  CreatedOn = DateTime.Now
            });
            builder.HasData(new Category("STEM","Stands for Science, Technology, Engineering, and Mathematics. It encompasses a wide range of fields related to scientific and technological advancements"){
                 CreatedBy ="Admin",
                  CreatedOn = DateTime.Now
            });
            builder.HasData(new Category("Business and Management","Encompasses the study of various aspects of running a business,Involves understanding how to plan, organize, lead, and control business operations"){
                 CreatedBy ="Admin",
                  CreatedOn = DateTime.Now
            });
            builder.HasData(new Category("Humanities","Encompasses the study of human culture, society, and the arts"){
                 CreatedBy ="Admin",
                  CreatedOn = DateTime.Now
            });
        }
    }
}