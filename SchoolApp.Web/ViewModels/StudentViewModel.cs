namespace SchoolApp.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StudentViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter first name")]

        public string FirstName { get; set; }
        public string MidName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; }

        //public ICollection<SelectListItem> CourseCheckBoxes { get; set; }

        //public ICollection<CourseViewModel> AllCourses { get; set; }

        public string FullName
        {
            get
            {
                if (MidName == null)
                {
                    return FirstName + " " + LastName;
                }

                return FirstName + " " + MidName + " " + LastName;
            }
        }
    }
}
