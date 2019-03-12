namespace SchoolApp.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeacherViewModel
    {
        public TeacherViewModel()
        {
            this.Courses = new HashSet<CourseViewModel>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle name")]
        public string MidName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "E-mail address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; }

        //public ICollection<SelectListItem> CourseCheckBoxes { get; set; }

        public ICollection<CourseViewModel> AllCourses { get; set;}

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
