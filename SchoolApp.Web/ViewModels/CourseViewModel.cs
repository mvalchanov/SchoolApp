namespace SchoolApp.Web.ViewModels
{
    using System.Collections.Generic;

    public class CourseViewModel
    {
        public CourseViewModel()
        {
            this.Students = new HashSet<CourseStudentsViewModel>();
        }

        public int CourseID { get; set; }
        public string Name { get; set; }
        //public bool Assigned { get; set; }

        public int? TeacherID { get; set; }
        public TeacherViewModel Teacher { get; set; }

        public ICollection<CourseStudentsViewModel> Students { get; set; }
    }
}
