namespace SchoolApp.Models
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }
        public ICollection<Course> Courses { get; set; }
    }
}