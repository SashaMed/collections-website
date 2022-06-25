using Microsoft.AspNetCore.Mvc;

namespace Course_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
