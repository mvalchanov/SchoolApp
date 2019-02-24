
namespace SchoolApp.Models
{
    using System.Collections.Generic;

    public class Student : Person
    {
        public Student()
        {
            this.Courses = new HashSet<CourseStudents>();
        }
        public ICollection<CourseStudents> Courses { get; set; }
    }
}
