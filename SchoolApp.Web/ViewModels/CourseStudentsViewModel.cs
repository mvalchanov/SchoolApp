namespace SchoolApp.Web.ViewModels
{
    public class CourseStudentsViewModel
    {
        public int CourseID { get; set; }
        public CourseViewModel Course { get; set; }
        public int StudentID { get; set; }
        public StudentViewModel Student { get; set; }
    }
}
