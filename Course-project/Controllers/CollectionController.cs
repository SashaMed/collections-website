using Microsoft.AspNetCore.Mvc;

namespace Course_project.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
