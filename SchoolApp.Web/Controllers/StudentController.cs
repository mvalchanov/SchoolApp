namespace SchoolApp.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data;
    using SchoolApp.Data.Repository;
    using SchoolApp.Web.ViewModels;
    using System.Collections.Generic;

    public class StudentController : BaseController
    {
        private readonly IStudentRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ApplicationDbContext _context;


        public StudentController(IStudentRepository repository,
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
            List<StudentViewModel> students = _mapper.Map<List<StudentViewModel>>(_userRepository.GetAll(true));
            return View(students);
        }
    }
}
