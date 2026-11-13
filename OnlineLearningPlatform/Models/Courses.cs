using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Level { get; set; }
        public Boolean IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? InstructorId { get; set; }
        public Instructors? Instructor { get; set; }
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }
        public List<Enrollments>? Enrollments { get; set; }
    }

}
