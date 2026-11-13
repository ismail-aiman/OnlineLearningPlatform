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
    public class EnrollmentsConfig : IEntityTypeConfiguration<Enrollments>
    {
        public void Configure(EntityTypeBuilder<Enrollments> builder)
        {
            builder.HasKey(e => new { e.CourseId, e.StudentId });
            builder.HasOne(e => e.Student)
                    .WithMany(e => e.Enrollments)
                    .HasForeignKey(e => e.StudentId);
            builder.HasOne(e=>e.Course)
                    .WithMany(e=>e.Enrollments)
                    .HasForeignKey(e=>e.CourseId);
        }
    }
}
