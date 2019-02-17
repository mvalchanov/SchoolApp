namespace SchoolApp.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SchoolApp.Data.Repository;
    using SchoolApp.Models;
    using SchoolApp.Web.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly SignInManager<IdentityUser> signInManager;
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository repository)
        {
            this._userRepository = repository;
        }

        //public AccountController(UserManager<IdentityUser> userManager,
        //    SignInManager<IdentityUser> signInManager)
        //{
        //    this.userManager = userManager;
        //    this.signInManager = signInManager;
        //}


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Users()
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

        public ViewResult Login(string returnUrl)
        {
            return View(new User
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            //if (ModelState.IsValid)
            //{
            //    IdentityUser identityUser = await userManager.FindByNameAsync(user.Username);
            //    if (user != null)
            //    {
            //        await signInManager.SignOutAsync();
            //        if ((await signInManager.PasswordSignInAsync(identityUser, user.Password, false, false)).Succeeded)
            //        {
            //            return Redirect(user?.ReturnUrl ?? "/Admin/Index");
            //        }
            //    }
            //}
            //ModelState.AddModelError("", "Invalid username or password.");
            return View(user);
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Register(User user)
        {
            return View();
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            //await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
