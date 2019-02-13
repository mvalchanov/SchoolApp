namespace SchoolApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Group
    {
        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
