namespace SchoolApp.Models
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        public ICollection<Course> Courses { get; set; }
    }
}