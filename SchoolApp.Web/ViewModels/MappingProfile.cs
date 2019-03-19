namespace SchoolApp.Web.ViewModels
{
    using AutoMapper;
    using SchoolApp.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherViewModel>(MemberList.Destination)
                .ReverseMap();

            CreateMap<Course, CourseViewModel>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CourseViewModel, TeacherViewModel>(MemberList.Destination)
                .ReverseMap();

            CreateMap<Student, StudentViewModel>(MemberList.Destination)
                .ReverseMap();

            CreateMap<Student, CourseStudents>()
                .ReverseMap();
            CreateMap<Course, CourseStudents>()
                .ReverseMap();

            CreateMap<StudentViewModel, CourseStudentsViewModel>()
                .ReverseMap();
            CreateMap<CourseViewModel, CourseStudentsViewModel>()
                .ReverseMap();

            CreateMap<CourseStudents, CourseStudentsViewModel>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                .ForMember(dest => dest.CourseID, opt => opt.MapFrom(src => src.CourseID))
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src=>src.Student))
                .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src=>src.StudentID))
                .ReverseMap();
        }
    }
}
