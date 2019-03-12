namespace SchoolApp.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data;
    using SchoolApp.Data.Repository;
    using SchoolApp.Web.ViewModels;
    using System.Collections.Generic;

    public class CourseController : BaseController
    {
        private readonly ITeacherRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ApplicationDbContext _context;


        public CourseController(ITeacherRepository repository,
            ICourseRepository courseRepository,
            ApplicationDbContext context,
            IMapper mapper)
            : base(mapper)
        {
            this._userRepository = repository;
            this._courseRepository = courseRepository;
            this._context = context;
        }

        public IActionResult Index()
        {
            var test = _courseRepository.GetAll(true, true);
            var courses = _mapper.Map<List<CourseViewModel>>(_courseRepository.GetAll(true, true));
            
            return View(courses);
        }
        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                CourseViewModel course = _mapper.Map<CourseViewModel>(_courseRepository.GetById(id));
                //course.Students = _mapper.Map<List<StudentViewModel>>(_courseRepository.)
                return View(course);
            }

            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
