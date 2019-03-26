namespace SchoolApp.Models
{
    using System.Collections.Generic;

    public class Teacher
    {
        
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }
        public int TeacherID { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}