using Microsoft.AspNetCore.Mvc;

namespace KayanProject1.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
