using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}