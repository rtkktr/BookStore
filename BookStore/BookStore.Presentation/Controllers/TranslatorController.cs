using BookStore.Domain.Models;
using BookStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TranslatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Translator
        public async Task<IActionResult> Index()
        {
              return _context.Translator != null ? 
                          View(await _context.Translator.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Translator'  is null.");
        }

        // GET: Translator/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Translator == null)
            {
                return NotFound();
            }

            var translator = await _context.Translator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        // GET: Translator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Translator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Description,DateCreation,DateModification,IsDeleted,Id")] Translator translator)
        {
            if (ModelState.IsValid)
            {
                translator.Id = Guid.NewGuid();
                _context.Add(translator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(translator);
        }

        // GET: Translator/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Translator == null)
            {
                return NotFound();
            }

            var translator = await _context.Translator.FindAsync(id);
            if (translator == null)
            {
                return NotFound();
            }
            return View(translator);
        }

        // POST: Translator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName,LastName,Description,DateCreation,DateModification,IsDeleted,Id")] Translator translator)
        {
            if (id != translator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslatorExists(translator.Id))
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
            return View(translator);
        }

        // GET: Translator/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Translator == null)
            {
                return NotFound();
            }

            var translator = await _context.Translator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        // POST: Translator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Translator == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Translator'  is null.");
            }
            var translator = await _context.Translator.FindAsync(id);
            if (translator != null)
            {
                _context.Translator.Remove(translator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslatorExists(Guid id)
        {
          return (_context.Translator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
