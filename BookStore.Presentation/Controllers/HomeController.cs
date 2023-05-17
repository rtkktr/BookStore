using BookStore.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository<Guid?, bool?> _bookRepository;

        public HomeController(IBookRepository<Guid?, bool?> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            //await _bookRepository.InsertAsync(new BookStore.Domain.Models.Book
            //{
              //  Id = new Guid(),
                //LongDescription = "abcdefg",
                //PageNumber = 10,
                //ProductCode = 1,
                //PublishYear = 1400,
                //Title = "Title",
                //ShortDescription = "abc",
                //UnitPrice = 10,
                //Weight = 10,
            //});
            return View();
        }
    }
}