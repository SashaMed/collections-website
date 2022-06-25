using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course_project.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
