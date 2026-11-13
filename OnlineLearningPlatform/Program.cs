using Microsoft.EntityFrameworkCore;

namespace OnlineLearningPlatform
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDBContext();
            context.Database.Migrate();
            DataSeeding.SeedData(context);
            //Operations.AddInstructor(context);
            //Operations.AddCourse(context);
            //Operations.AddRangeStudents(context);
            //Operations.EnrollStudent(context, 1, 1);
            //Operations.FindCourse(context);
            //Operations.FilterCourses(context);
            //Operations.PrintSubCat(context,1);
            //Operations.StudentsInCourse(context,1);
            //Operations.ChangePrice(context,1);
            //Operations.UpdateProgress(context, 1, 1, 100);
            //Operations.PublishCourse(context,1);
            //Operations.DeleteEnroll(context);
            //Operations.DeleteCat(context);
            //Operations.SafeDeleteCat(context,1);
            //Operations.DeleteCourse(context,1);
            //Operations.BulkPriceRaise(context);
            Operations.BulkDelete(context);

        }
    }
}
