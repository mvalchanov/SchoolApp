
namespace SchoolApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Data;
    using SchoolApp.Data.Repository;
    using SchoolApp.Models;
    using SchoolApp.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ApplicationDbContext _context;

        public TeacherController(ITeacherRepository repository,
            ICourseRepository courseRepository,
            ApplicationDbContext context)
        {
            this._userRepository = repository;
            this._courseRepository = courseRepository;
            this._context = context;
        }
        public IActionResult Index()
        {
            AllTeachersViewModel viewModel = new AllTeachersViewModel();
            viewModel.Teachers = _userRepository.GetAll(true);
            viewModel.Courses = _courseRepository.GetAll(true);

            return View(viewModel);
        }

        public IActionResult Create()
        {
            CreateTeacherViewModel createTeacher = new CreateTeacherViewModel();
            createTeacher.Teacher = new Teacher();
            createTeacher.Courses = _courseRepository
                .GetAll(true)
                .Where(t => t.Teacher == null);

            return View(createTeacher);
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                var dbTeacher = teacher;
                teacher.Courses = new HashSet<Course>();
                foreach (var course in selectedCourses)
                {
                    teacher.Courses.Add(_userRepository.GetCourseById(course));
                }
                _userRepository.Add(teacher);

                ViewData["message"] = $"{teacher.FirstName} {teacher.LastName} successfuly created.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["errormessage"] = $"There was a problem creating {teacher.FirstName} {teacher.LastName}. Please try again.";
                return View();
            }
        }

        public IActionResult Edit(int id)
        {

            var user = _userRepository.GetById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Teacher user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Edit(user);
                TempData["message"] = $"{user.FirstName} {user.LastName} has been edited.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["errormessage"] = $"There was a problem editing {user.FirstName} {user.LastName}. Please try again.";
                return View("Edit", user);
            }
        }

        public IActionResult Delete(int id)
        {

            var user = _userRepository.GetById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = $"{teacher.FirstName} {teacher.LastName} has been deleted.";
                _userRepository.Delete(teacher.ID);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = $"There was a problem while trying to delete {teacher.FirstName} {teacher.LastName}. Please try again.";

                return View();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Teachers
                .Include(g => g.Courses)
                .ThenInclude(s => s.Students)
                .FirstOrDefaultAsync(u => u.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

    }
}
