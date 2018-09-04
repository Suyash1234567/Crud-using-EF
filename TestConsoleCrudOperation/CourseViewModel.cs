using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleCrudOperation
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentViewModel> Students { get; set; }
    }
}

namespace TestConsoleCrudOperation
{
    public class StudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentClass { get; set; }
        public int CourseId {get; set;}
        public CourseViewModel CourseViewModel { get; set; }
    }
}

