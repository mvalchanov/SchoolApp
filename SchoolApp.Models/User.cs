namespace SchoolApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Groups = new HashSet<Group>();
        }

        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        public bool IsTeacher { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
