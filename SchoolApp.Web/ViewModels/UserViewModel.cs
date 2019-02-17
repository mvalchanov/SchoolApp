namespace SchoolApp.Web.ViewModels
{
    using SchoolApp.Models;
    using System.Collections.Generic;

    public class UserViewModel
    {
        public User User { get; set; }
        public ICollection<UserGroup> Groups { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public ICollection<Group> Groups { get; set; }
    }
}
