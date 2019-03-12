namespace SchoolApp.Web.ViewModels
{
    using AutoMapper;
    using SchoolApp.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherViewModel>()
                .ReverseMap();

            CreateMap<Course, CourseViewModel>()
                .ReverseMap();

            CreateMap<Student, StudentViewModel>()
                .ReverseMap();

            CreateMap<CourseStudents, CourseStudentsViewModel>()
                .ReverseMap();
        }
    }
}
