namespace SchoolApp.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Groups = new HashSet<UserGroup>();
        }

        public int UserId { get; set; }
        
        public string Username { get; set; }
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string Password { get; set; }
        
        public bool IsTeacher { get; set; }

        public string ReturnUrl { get; set; } = "/";

        public virtual ICollection<UserGroup> Groups { get; set; }
    }
}
