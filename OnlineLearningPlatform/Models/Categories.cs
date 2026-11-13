using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public Categories? ParentCategory { get; set; }
        public List<Categories> SubCategories { get; set; }
        public List<Courses>? Courses { get; set; }

    }
}
