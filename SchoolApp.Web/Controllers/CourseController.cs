namespace SchoolApp.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data;
    using SchoolApp.Data.Repository;
    using SchoolApp.Models;
    using SchoolApp.Web.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class CourseController : BaseController
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public CourseController(ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IMapper mapper)
            : base(mapper)
        {
            this._teacherRepository = teacherRepository;
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            List<CourseViewModel> courses = _mapper.Map<List<CourseViewModel>>(_courseRepository.GetAll(true, true));

            return View(courses);
        }
        public IActionResult Edit(int id)
        {
            //TODO: Fix Assigned/Unassigned students

            CourseViewModel course = _mapper.Map<CourseViewModel>(_courseRepository.GetById(id,
                includeStudents: true,
                includeTeacher: true));

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel course, int[] addStudents, int[] removeStudents)
        {
            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = $"Unsuccessfully edited! :(";
                return View(nameof(Index));
            }

            Course dbCourse = _mapper.Map<Course>(course);

            _courseRepository.Edit(dbCourse);
            _courseRepository.Save();

            dbCourse = _courseRepository.GetById(course.CourseID, includeStudents: true);

            if (addStudents.Any())
            {
                foreach (var student in addStudents)
                {
                    dbCourse.Students.Add(new CourseStudents()
                    {
                        StudentID = student,
                        CourseID = dbCourse.CourseID
                    });

                }
                _courseRepository.Save();
            }

            TempData["message"] = $"Successfully edited!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            CourseViewModel course = new CourseViewModel();
            return View();
        }

        [HttpPost]
        public IActionResult Create (CourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Course crs = _mapper.Map<Course>(course);

            _courseRepository.Add(crs);
            _courseRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            CourseViewModel course = _mapper.Map<CourseViewModel>(_courseRepository.GetById(id,
                includeStudents: true,
                includeTeacher: true));

            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(CourseViewModel viewCourse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _courseRepository.Delete(viewCourse.CourseID);
            _courseRepository.Save();

            TempData["success"] = $"Course has been deleted.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            CourseViewModel course = _mapper.Map<CourseViewModel>(_courseRepository.GetById(id));

            return View(course);
        }
    }
}
