namespace SchoolApp.Web.ViewModels
{
    using System.Collections.Generic;

    public class CourseViewModel
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        //public bool Assigned { get; set; }

        public int? TeacherID { get; set; }
        public TeacherViewModel Teacher { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}
