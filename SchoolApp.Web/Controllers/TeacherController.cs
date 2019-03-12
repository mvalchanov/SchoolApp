
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
            List<TeacherViewModel> viewModel = _mapper.Map<List<TeacherViewModel>>(_userRepository.GetAll(true));

            return View(viewModel);
        }

        public IActionResult Create()
        {
            TeacherViewModel createTeacher = new TeacherViewModel
            {
                Courses = _mapper.Map<ICollection<CourseViewModel>>(_courseRepository
                .GetAll(true, true)
                .Where(t => t.Teacher == null))
            };

            //createTeacher.CourseCheckBoxes = _courseRepository
            //    .GetAll(true)
            //    .Where(t => t.Teacher == null)
            //    .Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.CourseID.ToString()
            //    })
            //    .ToList();

            return View(createTeacher);
        }

        [HttpPost]
        public IActionResult Create(TeacherViewModel teacher, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                foreach (var course in selectedCourses)
                {
                    var cour = _mapper.Map<CourseViewModel>(_courseRepository.GetById(course));
                    teacher.Courses.Add(cour);
                }
                _userRepository.Add(_mapper.Map<Teacher>(teacher));

                ViewData["message"] = $"{teacher.FirstName} {teacher.LastName} successfuly created.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["errormessage"] = $"There was a problem creating {teacher.FirstName} {teacher.LastName}. Please try again.";
                return View();
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeacherViewModel teacher = _mapper.Map<TeacherViewModel>(_userRepository
                .GetById(id));
            teacher.AllCourses = _mapper.Map<ICollection<CourseViewModel>>(_courseRepository
                .GetAll(true, true)
                .Where(t => t.Teacher == null));

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(TeacherViewModel user, int[] addCourses, int[] deleteCourses)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            if (ModelState.IsValid)
            {
                var dbUser = _userRepository
                    .GetById(user.ID);

                user.Courses = new HashSet<CourseViewModel>();

                user.Courses = _mapper.Map<ICollection<CourseViewModel>>(_userRepository
                    .GetAll(true));
                if (deleteCourses.Any())
                {
                    foreach (var course in deleteCourses)
                    {
                        user.Courses.Remove(_mapper.Map<CourseViewModel>(_courseRepository
                            .GetById(course)));
                    }
                }
                if (addCourses.Any())
                {
                    foreach (var course in addCourses)
                    {
                        user.Courses.Add(_mapper.Map<CourseViewModel>(_courseRepository
                            .GetById(course)));
                    }
                }
                //_userRepository.Edit(user);
                TempData["message"] = $"{user.FullName} has been edited.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errormessage"] = $"There was a problem editing {user.FullName}. Please try again.";
                return View("Edit", user);
            }
        }

        public IActionResult Delete(int id)
        {

            TeacherViewModel user = _mapper.Map<TeacherViewModel>(_userRepository
                .GetById(id));

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.Delete(teacher.ID);
                }
                catch (Exception)
                {
                    TempData["errorMessage"] = $"There was a problem while trying to delete {teacher.FullName}. Please try again.";

                    return View();
                }
                TempData["message"] = $"{teacher.FullName} has been deleted.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
