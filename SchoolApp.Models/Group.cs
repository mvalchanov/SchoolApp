namespace SchoolApp.Models
{
    using System.Collections.Generic;

    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<UserGroup>();
        }

        public int GroupId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserGroup> Users { get; set; }
    }
}
