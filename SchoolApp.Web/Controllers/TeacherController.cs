
namespace SchoolApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Data;
    using SchoolApp.Data.Repository;
    using SchoolApp.Models;
    using SchoolApp.Web.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeacherController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;

        public TeacherController(IUserRepository repository, ApplicationDbContext context)
        {
            this._userRepository = repository;
            this._context = context;
        }
        public IActionResult Index()
        {

            List<User> teachers = _context.Users
                .Include(g => g.Groups)
                .ThenInclude(s => s.Group)
                .ToList();
            
            //foreach (var user in teacherDb)
            //{
            //    teachers.Add(new User()
            //    {
            //         = user,
            //        Groups = user.Groups
            //    });
            //}

            return View(teachers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Add(user);
                ViewData["message"] = $"{user.FirstName} {user.LastName} successfuly created.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["errormessage"] = $"There was a problem creating {user.FirstName} {user.LastName}. Please try again.";
                return View();
            }
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
        public IActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = $"{user.FirstName} {user.LastName} has been deleted.";
                _userRepository.Delete(user.UserId);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = $"There was a problem while trying to delete {user.FirstName} {user.LastName}. Please try again.";

                return View();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(g => g.Groups)
                .ThenInclude(s => s.Group)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

    }
}
