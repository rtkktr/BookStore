using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository<Guid?, bool, RepositoryStatus> _bookRepository;

        public HomeController(IBookRepository<Guid?, bool, RepositoryStatus> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var (books, status) = await _bookRepository.SelectAllAsync();
            return View(books);   
        }
    }
}