using BookStore.Domain.Models;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository<Guid?, bool, RepositoryStatus> _publisherRepository;

        public PublisherController(IPublisherRepository<Guid?, bool, RepositoryStatus> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET: Publisher
        public async Task<IActionResult> Index()
        {
            var (publishers, publishersStatus) = await _publisherRepository.SelectAllAsync();
            switch(publishersStatus)
            {
                case RepositoryStatus.Success: 
                    return View(publishers);
                case RepositoryStatus.DatabaseError:
                case RepositoryStatus.TableIsEmpty: 
                    return View(new List<Publisher>());
            }
            return View();
        }

        // GET: Publisher/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var (publishers, publishersStatus) = await _publisherRepository.SelectAllAsync();
            if (id == null || publishers == null)
            {
                return NotFound();
            }

            var (publisher, publisherStatus) = await _publisherRepository.SelectByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publisher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publisher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,DateCreation,DateModification,IsDeleted,Id")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                publisher.Id = Guid.NewGuid();
                await _publisherRepository.InsertAsync(publisher);
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publisher/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var (publishers, publishersStatus) = await _publisherRepository.SelectAllAsync();
            if (id == null || publishers == null)
            {
                return NotFound();
            }

            var (publisher, publisherStatus) = await _publisherRepository.SelectByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publisher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Description,DateCreation,DateModification,IsDeleted,Id")] Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _publisherRepository.UpdateAsync(publisher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.Id))
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
            return View(publisher);
        }

        // GET: Publisher/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var (publishers, publishersStatus) = await _publisherRepository.SelectAllAsync();
            if (id == null || publishers == null)
            {
                return NotFound();
            }

            var (publisher, publisherStatus) = await _publisherRepository.SelectByIdAsync(id);
         
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var (publishers, publishersStatus) = await _publisherRepository.SelectAllAsync();
            if (publishers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Publisher'  is null.");
            }
            var (publisher, publisherStatus) = await _publisherRepository.SelectByIdAsync(id);
            if (publisher != null)
            {
               await _publisherRepository.DeleteAsync(publisher);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(Guid id)
        {
          var (publisherExist, status) = _publisherRepository.IsExist(id);
          return publisherExist;
        }
    }
}
