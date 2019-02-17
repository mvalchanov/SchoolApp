namespace SchoolApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data.Repository;
    using SchoolApp.Models;
    using SchoolApp.Web.ViewModels;

    public class HomeController : Controller
    {
        private IUserRepository _userRepository { get; }

        public HomeController(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public IActionResult Index()
        {

            List<UserViewModel> allUsers = new List<UserViewModel>();

            foreach (var user in _userRepository.GetAll(true))
            {
                allUsers.Add(new UserViewModel()
                {
                    User = user,
                    Groups = user.Groups
                });
            }
            return View(allUsers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
