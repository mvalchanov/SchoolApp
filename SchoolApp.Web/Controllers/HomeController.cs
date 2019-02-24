namespace SchoolApp.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data.Repository;
    using SchoolApp.Web.ViewModels;

    public class HomeController : Controller
    {
        private ITeacherRepository _userRepository { get; }
        private ICourseRepository _courseRepository { get; }

        public HomeController(ITeacherRepository repository,
            ICourseRepository courseRepository)
        {
            _userRepository = repository;
            _courseRepository = courseRepository;
        }

        public IActionResult LoginIndex()
        {

            //List<UserViewModel> allUsers = new List<UserViewModel>();

            //foreach (var user in _userRepository.GetAll(true))
            //{
            //    allUsers.Add(new UserViewModel()
            //    {
            //        User = user,
            //        Groups = user.Groups
            //    });
            //}
            return View("LoginIndex");
        }

        public IActionResult Index()
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
