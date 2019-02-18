
namespace SchoolApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data.Repository;
    using SchoolApp.Models;
    using SchoolApp.Web.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class TeacherController : Controller
    {
        private readonly IUserRepository _userRepository;

        public TeacherController(IUserRepository repository)
        {
            this._userRepository = repository;
        }
        public IActionResult Index()
        {

            List<TeacherViewModel> teachers = new List<TeacherViewModel>();

            foreach (var user in _userRepository.GetAll(true).Where(t => t.IsTeacher == true))
            {
                teachers.Add(new TeacherViewModel()
                {
                    Teacher = user,
                    Groups = user.Groups
                });
            }

            return View(teachers);
        }

        public IActionResult Edit(int id)
        {

            var user = _userRepository.GetById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Edit(user);
                TempData["message"] = $"{user.FirstName} {user.LastName} has been edited";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", user);
            }
        }
    }
}
