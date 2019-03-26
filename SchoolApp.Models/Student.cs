
namespace SchoolApp.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<CourseStudents>();
        }
        public int StudentID { get; set; }
        public ICollection<CourseStudents> Courses { get; set; }
    }
}
