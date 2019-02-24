namespace SchoolApp.Web.ViewModels
{
    using SchoolApp.Models;
    using System.Collections.Generic;

    public class TeacherViewModel
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
