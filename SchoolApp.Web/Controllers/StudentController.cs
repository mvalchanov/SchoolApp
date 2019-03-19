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

    public class StudentController : BaseController
    {
        private readonly IStudentRepository _userRepository;
        private readonly ICourseRepository _courseRepository;


        public StudentController(IStudentRepository repository,
            ICourseRepository courseRepository,
            IMapper mapper)
            : base(mapper)
        {
            this._userRepository = repository;
            this._courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            List<StudentViewModel> students = _mapper.Map<List<StudentViewModel>>(_userRepository.GetAll(includeGroups: true));
            return View(students);
        }

        public IActionResult Create()
        {
            //Student dbStudent = new Student();
            //dbStudent.Courses = _mapper.Map<ICollection<CourseStudents>>(_courseRepository.GetAll(true,true));
            //StudentViewModel student = _mapper.Map<StudentViewModel>(dbStudent);
            StudentViewModel student = new StudentViewModel
            {
                //Courses = _mapper
                //    .Map<ICollection<CourseStudentsViewModel>>(_courseRepository
                //        .GetAll())
            };

            return View(student);
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel viewStudent)
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = $"There was a problem creating {viewStudent.FullName}. Please try again.";
                return View(nameof(Create), viewStudent);
            }

            Student student = _mapper.Map<Student>(viewStudent);

            _userRepository.Add(student);
            _userRepository.Save();

            ViewData["success"] = $"{viewStudent.FullName} successfuly created.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            StudentViewModel student = _mapper.Map<StudentViewModel>(_userRepository
                .GetById(id, includeCourses: true));

            student.AllCourses = _mapper.Map<ICollection<CourseViewModel>>(_courseRepository
                .GetAll());

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel viewStudent, int[] deleteCourses, int[] addCourses)
        {
            if (!ModelState.IsValid)
            {
                TempData["errormessage"] = $"There was a problem editing {viewStudent.FullName}. Please try again.";
                return View("Edit", viewStudent);
            }

            Student student = _mapper.Map<Student>(viewStudent);

            _userRepository.Edit(student);
            _userRepository.Save();

            student = _userRepository
                .GetById(viewStudent.ID, includeCourses: true);


            if (deleteCourses.Any())
            {
                foreach (var courseId in deleteCourses)
                {
                    student.Courses.Remove(_mapper.Map<CourseStudents>(_courseRepository.GetById(courseId)));
                }
            }

            if (addCourses.Any())
            {
                foreach (var courseId in addCourses)
                {
                    student.Courses.Add(_mapper.Map<CourseStudents>(_courseRepository.GetById(courseId)));
                }
            }

            _userRepository.Edit(student);
            _userRepository.Save();

            TempData["message"] = $"{viewStudent.FullName} has been edited.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            StudentViewModel student = _mapper.Map<StudentViewModel>(_userRepository
                .GetById(id, includeCourses: true));

            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _userRepository.Delete(student.ID);
            _userRepository.Save();

            TempData["success"] = $"{student.FullName} has been deleted.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            StudentViewModel student = _mapper.Map<StudentViewModel>(_userRepository
                .GetById(id, includeCourses: true));

            return View(student);
        }
    }
}
