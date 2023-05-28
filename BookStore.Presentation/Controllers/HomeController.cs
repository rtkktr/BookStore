using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}