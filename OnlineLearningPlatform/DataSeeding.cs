using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform
{
    public static class DataSeeding
    {
        public static void SeedData(AppDBContext context) 
        {
            if (!context.Student.Any()) 
            {
                context.Student.AddRange(
                        new Students {FullName="ismail ayman",Email="@gmail",DateOfBirth=DateTime.Now },
                        new Students { FullName = "semsem", Email = "@yahoo", DateOfBirth = DateTime.Now },
                        new Students { FullName = "ismail", Email = "@hotmail", DateOfBirth = DateTime.Now },
                        new Students { FullName = "hamza", Email = "@yango", DateOfBirth = DateTime.Now },
                        new Students { FullName = "sayed", Email = "@google", DateOfBirth = DateTime.Now }
                    );
                context.SaveChanges();
            }
            if (!context.Enrollment.Any()) 
            {
                context.Enrollment.AddRange(
                        new Enrollments {StudentId=1,CourseId=1,EnrollmentDate=DateTime.Now,ProgressPercentage=90,Status="Active" },
                        new Enrollments { StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now, ProgressPercentage = 100, Status = "Completed" },
                        new Enrollments { StudentId = 4, CourseId = 3, EnrollmentDate = DateTime.Now, ProgressPercentage = 5, Status = "Active" },
                        new Enrollments { StudentId = 3, CourseId = 4, EnrollmentDate = DateTime.Now, ProgressPercentage = 45, Status = "Active" },
                        new Enrollments { StudentId = 5, CourseId = 5, EnrollmentDate = DateTime.Now, ProgressPercentage = 12, Status = "Active" },
                        new Enrollments { StudentId = 3, CourseId = 2, EnrollmentDate = DateTime.Now, ProgressPercentage = 16, Status = "Active" },
                        new Enrollments { StudentId = 4, CourseId = 1, EnrollmentDate = DateTime.Now, ProgressPercentage = 33, Status = "Active" },
                        new Enrollments { StudentId = 5, CourseId = 6, EnrollmentDate = DateTime.Now, ProgressPercentage = 99, Status = "Dropped" },
                        new Enrollments { StudentId = 1, CourseId = 5, EnrollmentDate = DateTime.Now, ProgressPercentage = 4, Status = "Active" }
                    );
                context.SaveChanges();
            }
        }
    }
}
