using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform
{
    public class Operations
    {
        #region Create
        public static void AddInstructor(AppDBContext context)
        {
            var instructor = new Instructors { FullName = "amgad ahmad", Email = "@ahsnd", JoinedDate = DateTime.Now };
            context.Instructor.Add(instructor);
            context.SaveChanges();
            Console.WriteLine($"Instructor Id = {instructor.Id}");
        }
        public static void AddCourse(AppDBContext context)
        {
            if (!context.Instructor.Any()) { Console.WriteLine("No instructor"); return; }
            if (!context.Catregory.Any()) { Console.WriteLine("No Category"); return; }
            var course = new Courses { InstructorId = 1, CategoryId = 2, Title = "asdas", Price = 100, Level = "asda" };
            context.Courses.Add(course);
            context.SaveChanges();
        }
        public static void AddRangeStudents(AppDBContext context)
        {
            var students = new List<Students>
                        {
                        new Students { FullName = "ismail ayman", Email = "@gmail", DateOfBirth = DateTime.Now },
                        new Students { FullName = "semsem", Email = "@yahoo", DateOfBirth = DateTime.Now },
                        new Students { FullName = "ismail", Email = "@hotmail", DateOfBirth = DateTime.Now }
            };
            context.Student.AddRange(students);
            context.SaveChanges();
            foreach (var student in students)
            {
                Console.WriteLine(student.Id);
            }
        }
        public static void EnrollStudent(AppDBContext context, int studentId, int courseId)
        {
            var student = context.Student.FirstOrDefault(s => s.Id == studentId);
            if (student == null) { Console.WriteLine("Student not found"); return; }
            var course = context.Courses.FirstOrDefault(s => s.Id == courseId);
            if (course == null) { Console.WriteLine("Course not found"); return; }
            if (!course.IsPublished) { Console.WriteLine("Course Is not published"); return; }
            var enrolled = context.Enrollment.Any(e => e.StudentId == studentId && e.CourseId == courseId);
            if (enrolled) { Console.WriteLine("Already enrolled"); return; }
            var enroll = new Enrollments { StudentId = studentId, CourseId = courseId, EnrollmentDate = DateTime.Now, ProgressPercentage = 0 };
            context.Enrollment.Add(enroll);
            context.SaveChanges();
        }
        #endregion
        #region Read
        public static void FindCourse(AppDBContext context)
        {
            var course = context.Courses.Find(1);
            if (course == null)
                Console.WriteLine("Course not found");
            else
                Console.WriteLine("Course: " + course.Title);
            var course2 = context.Courses.FirstOrDefault(c => c.Title == "ASP.NET");
            if (course2 == null)
                Console.WriteLine("Course not found");
            else
                Console.WriteLine("Course: " + course2.Title);
        }
        public static void FilterCourses(AppDBContext context)
        {
            var courses = context.Courses.Where(c => c.Price >= 1000 && c.Price <= 5000)
                                            .OrderByDescending(c => c.Price)
                                            .Select(c => new { c.Title, c.Level, c.Price })
                                            .ToList();
            foreach (var c in courses)
            {
                Console.WriteLine($"{c.Title} - {c.Level} - {c.Price}");
            }
        }
        public static void PrintSubCat(AppDBContext context, int parentCat)
        {
            var subCat = context.Catregory.Where(c => c.ParentCategoryId == parentCat).ToList();
            if (!subCat.Any()) { Console.WriteLine("No Id Matching"); return; }
            foreach (var item in subCat)
            {
                Console.WriteLine(item.Name);
            }
            var topLevel = context.Catregory.Where(c => c.ParentCategoryId == null).ToList();
            if (!topLevel.Any()) { Console.WriteLine("No Id Matching"); return; }
            foreach (var item in topLevel)
            {
                Console.WriteLine($"Top Level : {item.Name}");
            }
        }
        public static void StudentsInCourse(AppDBContext context, int courseId)
        {
            var students = context.Enrollment.Where(s => s.CourseId == courseId).Select(s => s.StudentId).ToList();
            Console.WriteLine(students.Count);
            var studentName = context.Student.Where(s => students.Contains(s.Id)).ToList();
            foreach (var item in studentName)
            {
                Console.WriteLine(item.FullName);
            }
        }
        #endregion
        #region Update
        public static void ChangePrice(AppDBContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine("Course Not Found");
                return;
            }
            course.Price = 1;
            context.SaveChanges();
        }
        public static void UpdateProgress(AppDBContext context, int courseId, int studentId, int newProgress)
        {
            if (newProgress < 0 && newProgress > 100) { Console.WriteLine("Invalid progress"); return; }
            var student = context.Enrollment.Find(studentId, courseId);
            student.ProgressPercentage = newProgress;
            if (newProgress == 100) { student.Status = "Completed"; }
            context.SaveChanges();
        }
        public static void PublishCourse(AppDBContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine("Course Not Found");
                return;
            }
            course.IsPublished = true;
            course.PublishedAt = DateTime.Now;
            context.SaveChanges();
        }
        #endregion
        #region delete
        public static void DeleteEnroll(AppDBContext context)
        {
            var enrollment = context.Enrollment.Find(1, 1);
            context.Enrollment.Remove(enrollment);
            context.SaveChanges();
        }
        public static void DeleteCat(AppDBContext context)
        {
            var withSubCat = context.Catregory.Find(1);
            try
            {
                context.Catregory.Remove(withSubCat);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void SafeDeleteCat(AppDBContext context, int categoryId)
        {
            bool haveSub = context.Catregory.Any(c => c.ParentCategoryId == categoryId);
            if (haveSub) { Console.WriteLine("Cannot "); return; }
            bool haveCOurse = context.Courses.Any(c => c.CategoryId == categoryId);
            if (haveCOurse) { Console.WriteLine("Cannot "); return; }
            var category = context.Catregory.Find(categoryId);
            if (category == null) { Console.WriteLine("Category Not Found"); return; }
            context.Catregory.Remove(category);
            context.SaveChanges();
        }
        public static void DeleteCourse(AppDBContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);
            var before = context.Enrollment.Count(e => e.CourseId == courseId);
            Console.WriteLine($"Beofre: {before}");  //1
            context.Courses.Remove(course);
            context.SaveChanges();
            var after = context.Enrollment.Count(e => e.CourseId == courseId);
            Console.WriteLine($"Afetr: {after}");  //0
            //enrollment also deleted because of cascade delete
        }
        #endregion
        public static void BulkPriceRaise(AppDBContext context) 
        {
            var affect = context.Courses
                                .Where(c=>c.IsPublished && c.Level=="Beginner")
                                .ExecuteUpdate(s=>s.SetProperty(c=>c.Price,c=>c.Price * 1.10m));
            Console.WriteLine($"affected rows : {affect}");
        }
        public static void BulkDelete(AppDBContext context)
        {
            var affected = context.Enrollment
                .Where(e => e.Status == "Dropped")
                .ExecuteDelete();

            Console.WriteLine("Deleted Enrollments: " + affected);
        }
    }
}
