namespace SchoolApp.Web.ViewModels
{
    using SchoolApp.Models;
    using System.Collections.Generic;

    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
