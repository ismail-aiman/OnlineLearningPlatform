using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Models
{
    public class Enrollments
    {
        public DateTime EnrollmentDate { get; set; }
        [Range(0, 100)]
        public decimal ProgressPercentage { get; set; }
        public string Status { get; set; }
        public decimal? FinalGrade { get; set; }
        public int? StudentId { get; set; }
        public Students? Student { get; set; }
        public int? CourseId { get; set; }
        public Courses? Course { get; set; }

    }
}
