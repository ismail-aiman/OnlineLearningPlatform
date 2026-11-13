using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Configurations
{
    public class CategoriesConfig : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasOne(c => c.ParentCategory)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(c => c.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Categories { Id = 1,Name = "Programming" },
                new Categories { Id = 2, Name = "Backend", ParentCategoryId = 1 },
                new Categories { Id = 3, Name = "ASP.Net", ParentCategoryId = 2 },
                new Categories { Id = 4, Name = "Frontend", ParentCategoryId = 1 },
                new Categories { Id = 5, Name = "Is" }
                );
        }
    }
}
