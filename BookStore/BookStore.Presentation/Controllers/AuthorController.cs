using BookStore.Domain.Models;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository<Guid?, bool, RepositoryStatus> _authorRepository;

        public AuthorController(IAuthorRepository<Guid?, bool, RepositoryStatus> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: Author
        public async Task<IActionResult> Index()
        {
            var (authors, authorsStatus) = await _authorRepository.SelectAllAsync();
            switch (authorsStatus)
            {
                case RepositoryStatus.Success: 
                    return View(authors);
                case RepositoryStatus.DatabaseError:
                case RepositoryStatus.TableIsEmpty:
                    return View(new List<Author>());
            }
            return View();
        }

        // GET: Author/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var (authors, authorsStatus) = await _authorRepository.SelectAllAsync();
            if (id == null || authors == null)
            {
                return NotFound();
            }

            var (author, authorStatus) = await _authorRepository.SelectByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Description,DateCreation,DateModification,IsDeleted,Id")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();
                await _authorRepository.InsertAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var (authors, authorsStatus) = await _authorRepository.SelectAllAsync();
            if (id == null || authors == null)
            {
                return NotFound();
            }

            var (author, authorStatus) = await _authorRepository.SelectByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName,LastName,Description,DateCreation,DateModification,IsDeleted,Id")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _authorRepository.UpdateAsync(author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
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
            return View(author);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var (authors, authorsStatus) = await _authorRepository.SelectAllAsync();
            if (id == null || authors == null)
            {
                return NotFound();
            }

            var (author, authorStatus) = await _authorRepository.SelectByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var (authors, authorsStatus) = await _authorRepository.SelectAllAsync();
            if (authors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Author'  is null.");
            }
            var (author, authorStatus) = await _authorRepository.SelectByIdAsync(id);
            if (author != null)
            {
                await _authorRepository.DeleteAsync(author);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(Guid id)
        {
            var (authorExist, status) = _authorRepository.IsExist(id);
            return authorExist;
        }
    }
}
