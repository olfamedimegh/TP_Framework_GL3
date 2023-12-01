using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TP5_test.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> _userManager)
        {
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }
    }
}
