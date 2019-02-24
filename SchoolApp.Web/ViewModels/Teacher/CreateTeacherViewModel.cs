
namespace SchoolApp.Web.ViewModels
{
    using SchoolApp.Models;
    using System.Collections.Generic;

    public class CreateTeacherViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
