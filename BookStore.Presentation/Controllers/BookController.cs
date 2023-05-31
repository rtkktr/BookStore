using BookStore.Domain.Models;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository<Guid?, bool, RepositoryStatus> _bookRepository;

        public BookController(IBookRepository<Guid?, bool, RepositoryStatus> bookRepository, ApplicationDbContext context)
        {
            _bookRepository = bookRepository;
        }



        // GET: Book
        public async Task<IActionResult> Index()
        {
            var (books, status) = await _bookRepository.SelectAllAsync();
            switch (status)
            {
                case RepositoryStatus.Success:
                    return View(books);
                case RepositoryStatus.DatabaseError:
                case RepositoryStatus.TableIsEmpty:
                    return View(new List<Book>());
            }
            return View();
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var (books, BooksStatus) = await _bookRepository.SelectAllAsync();
            if (id == null || books == null)
            {
                return NotFound();
            }

            var (book, bookStatus) = await _bookRepository.SelectByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCode,Title,PublishYear,PageNumber,ShortDescription,LongDescription,Weight,UnitPrice,DateCreation,DateModification,IsDeleted,Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                await _bookRepository.InsertAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var(books, booksStatus) = await _bookRepository.SelectAllAsync();
            if (id == null || books == null)
            {
                return NotFound();
            }

            var (book, bookStatus) = await _bookRepository.SelectByIdAsync(id); 
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductCode,Title,PublishYear,PageNumber,ShortDescription,LongDescription,Weight,UnitPrice,DateCreation,DateModification,IsDeleted,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookRepository.UpdateAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var (books, booksStatus) = await _bookRepository.SelectAllAsync();
            if (id == null || books == null)
            {
                return NotFound();
            }

            var (book, bookStatus) = await _bookRepository.SelectByIdAsync(id);
                
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var(books, booksStatus) = await _bookRepository.SelectAllAsync();
            if (books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
            }
            var (book, bookStatus) = await _bookRepository.SelectByIdAsync(id);
            if (book != null)
            {
                await _bookRepository.DeleteAsync(book);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(Guid id)
        {
            var (exist, status) = _bookRepository.IsExist(id);
          return exist;
        }
    }
}
