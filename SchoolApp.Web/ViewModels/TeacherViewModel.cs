namespace SchoolApp.Web.ViewModels
{
    using SchoolApp.Models;
    using System.Collections.Generic;

    public class TeacherViewModel
    {
        public User Teacher { get; set; }
        public ICollection<UserGroup> Groups { get; set; }
    }
}
