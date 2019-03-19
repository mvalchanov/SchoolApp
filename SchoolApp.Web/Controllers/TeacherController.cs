
namespace SchoolApp.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data.Repository;
    using SchoolApp.Models;
    using SchoolApp.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TeacherController : BaseController
    {
        private readonly ITeacherRepository _userRepository;
        private readonly ICourseRepository _courseRepository;


        public TeacherController(ITeacherRepository repository,
            ICourseRepository courseRepository,
            IMapper mapper)
            : base(mapper)
        {
            this._userRepository = repository;
            this._courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            List<TeacherViewModel> viewModel = _mapper.Map<List<TeacherViewModel>>(_userRepository
                .GetAll(includeCourses: true));

            return View(viewModel);
        }

        public IActionResult Create()
        {
            TeacherViewModel teacher = new TeacherViewModel
            {
                Courses = _mapper
                    .Map<ICollection<CourseViewModel>>(_courseRepository
                        .GetAll(includeStudents: true, includeTeacher: true)
                        .Where(t => t.Teacher == null))
                        
            };

            //teacher.CourseCheckBoxes = _courseRepository
            //    .GetAll(true)
            //    .Where(t => t.Teacher == null)
            //    .Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.CourseID.ToString()
            //    })
            //    .ToList();

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Create(TeacherViewModel viewTeacher, int[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = $"There was a problem creating {viewTeacher.FullName}. Please try again.";
                return View(nameof(Create), viewTeacher);
            }

            Teacher teacher = _mapper.Map<Teacher>(viewTeacher);

            foreach (var course in selectedCourses)
            {
                var crs = (_courseRepository.GetById(course));
                teacher.Courses.Add(crs);
            }

            _userRepository.Add(teacher);
            _userRepository.Save();

            ViewData["success"] = $"{viewTeacher.FullName} successfuly created.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {

            TeacherViewModel teacher = _mapper.Map<TeacherViewModel>(_userRepository
                .GetById(id, includeCourses: true));

            teacher.AllCourses = _mapper.Map<ICollection<CourseViewModel>>(_courseRepository
                .GetAll(includeStudents: true,includeTeacher: true)
                .Where(t => t.Teacher == null));

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(TeacherViewModel viewTeacher, int[] addCourses, int[] deleteCourses)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = $"There was a problem editing {viewTeacher.FullName}. Please try again.";
                return View("Edit", viewTeacher);
            }


            Teacher teacher = _mapper.Map<Teacher>(viewTeacher);

            _userRepository.Edit(teacher);
            _userRepository.Save();

            teacher = _userRepository
                .GetById(viewTeacher.ID, includeCourses: true);

            if (deleteCourses.Any())
            {
                foreach (var course in deleteCourses)
                {
                    teacher.Courses.Remove(_courseRepository.GetById(course));
                }
            }

            if (addCourses.Any())
            {
                foreach (var course in addCourses)
                {
                    teacher.Courses.Add(_courseRepository.GetById(course));
                }
            }

            _userRepository.Edit(teacher);
            _userRepository.Save();

            TempData["success"] = $"{viewTeacher.FullName} has been edited.";
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            TeacherViewModel teacher = _mapper.Map<TeacherViewModel>(_userRepository
                .GetById(id, includeCourses: true));

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Delete(TeacherViewModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _userRepository.Delete(teacher.ID);
            _userRepository.Save();

            TempData["success"] = $"{teacher.FullName} has been deleted.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            TeacherViewModel teacher = _mapper.Map<TeacherViewModel>(_userRepository
                .GetById(id, includeCourses: true));
            
            return View(teacher);
        }
    }
}
