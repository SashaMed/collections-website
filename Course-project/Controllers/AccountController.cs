using Course_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Course_project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }
    }
}
