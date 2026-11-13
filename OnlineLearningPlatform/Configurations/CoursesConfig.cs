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
    public class CoursesConfig : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasOne(c => c.Instructor)
                    .WithMany(c => c.Courses)
                    .HasForeignKey(c => c.InstructorId);
            builder.HasOne(c => c.Category)
                    .WithMany(c => c.Courses)
                    .HasForeignKey(c => c.CategoryId);
            builder.Property(c => c.Price)
                    .HasPrecision(8, 2);
            builder.HasData(
                new Courses {Id=1,CategoryId=1,InstructorId=1,Price=5000,Level="Beginner",Title="Back",IsPublished=true,PublishedAt= new DateTime(2020,1,1)},
                new Courses { Id = 2, CategoryId = 2, InstructorId = 2, Price = 50000, Level = "Advanced", Title = "Front", IsPublished = true, PublishedAt = new DateTime(2021, 1, 1) },
                new Courses { Id = 3, CategoryId = 4, InstructorId = 3, Price = 1000, Level = "Beginner", Title = "Mobile", IsPublished = false, PublishedAt = null },
                new Courses { Id = 4, CategoryId = 1, InstructorId = 1, Price = 5000, Level = "Beginner", Title = "Back", IsPublished = false, PublishedAt = null },
                new Courses { Id = 5, CategoryId = 5, InstructorId = 2, Price = 6000, Level = "Intermediate", Title = "DevOps", IsPublished = true, PublishedAt = new DateTime(2023, 1, 1) },
                new Courses { Id = 6, CategoryId = 3, InstructorId = 3, Price = 100, Level = "Beginner", Title = "Back", IsPublished = true, PublishedAt = new DateTime(2024, 1, 1) }
                );
        }
    }
}
