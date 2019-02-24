using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<CourseStudents>();
        }

        public int CourseID { get; set; }
        public string Name { get; set; }
        public int? TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<CourseStudents> Students { get; set; }
    }
}