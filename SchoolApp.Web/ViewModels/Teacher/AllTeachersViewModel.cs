
namespace SchoolApp.Web.ViewModels
{
    using SchoolApp.Models;
    using System.Collections.Generic;

    public class AllTeachersViewModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
