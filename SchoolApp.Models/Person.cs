using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
