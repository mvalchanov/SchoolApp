namespace SchoolApp.Web.ViewModels
{
    using AutoMapper;
    using SchoolApp.Models;
    using System.Collections.Generic;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherViewModel>()
                .ReverseMap();
        }
    }
}
