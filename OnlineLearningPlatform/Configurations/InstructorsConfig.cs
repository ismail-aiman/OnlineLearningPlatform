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
    public class InstructorsConfig : IEntityTypeConfiguration<Instructors>
    {
        public void Configure(EntityTypeBuilder<Instructors> builder)
        {
            builder.HasData(
                new Instructors {Id=1,FullName="ismail ayman",Email="@gmail",JoinedDate= new DateTime(2023, 1, 1) },
                new Instructors { Id = 2, FullName = "ismail hamza", Email = "@yahoo", JoinedDate = new DateTime(2022, 1, 1) },
                new Instructors { Id = 3, FullName = "semsem ayman", Email = "@hotmail", JoinedDate = new DateTime(2020, 1, 1) }
                );
        }
    }
}
