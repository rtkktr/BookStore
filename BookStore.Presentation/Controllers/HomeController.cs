using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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