using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Models
{
    public class Instructors
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string? Bio { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<Courses>? Courses { get; set; }

    }
}
