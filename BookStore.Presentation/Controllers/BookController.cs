using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository<Guid?, bool?> _bookRepository;

        public BookController(IBookRepository<Guid?, bool?> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.SelectAllAsync();
            return View(books);
        }
    }
}
