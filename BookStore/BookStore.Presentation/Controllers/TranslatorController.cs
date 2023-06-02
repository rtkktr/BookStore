using BookStore.Domain.Models;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly ITranslatorRepository<Guid?, bool, RepositoryStatus> _translatorRepository;

        public TranslatorController(ITranslatorRepository<Guid?, bool, RepositoryStatus> translatorRepository)
        {
            _translatorRepository = translatorRepository;
        }

        // GET: Translator
        public async Task<IActionResult> Index()
        {
            var (translators, translatorsStatus) = await _translatorRepository.SelectAllAsync();
            switch(translatorsStatus)
            {
                case RepositoryStatus.Success:
                    return View(translators);
                case RepositoryStatus.DatabaseError:
                case RepositoryStatus.TableIsEmpty:
                    return View(new List<Translator>());
            }
            return View();
        }

        // GET: Translator/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var (translators, translatorsStatus) = await _translatorRepository.SelectAllAsync();
            if (id == null || translators == null)
            {
                return NotFound();
            }

            var (translator, translatorStatus) = await _translatorRepository.SelectByIdAsync(id); 
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
                await _translatorRepository.InsertAsync(translator);
                return RedirectToAction(nameof(Index));
            }
            return View(translator);
        }

        // GET: Translator/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var (translators, translatorsStatus) = await _translatorRepository.SelectAllAsync();
            if (id == null || translators == null)
            {
                return NotFound();
            }

            var (translator, translatorStatus) = await _translatorRepository.SelectByIdAsync(id);
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
                    await _translatorRepository.UpdateAsync(translator);
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
            var (translators, translatorsStatus) = await _translatorRepository.SelectAllAsync();
            if (id == null || translators == null)
            {
                return NotFound();
            }

            var (translator, translatorStatus) = await _translatorRepository.SelectByIdAsync(id);
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
            var (translators, translatorsStatus) = await _translatorRepository.SelectAllAsync();
            if (translators == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Translator'  is null.");
            }
            var (translator, translatorStatus) = await _translatorRepository.SelectByIdAsync(id);
            if (translator != null)
            {
                await _translatorRepository.DeleteAsync(translator);
            }
           
            return RedirectToAction(nameof(Index));
        }

        private bool TranslatorExists(Guid id)
        {
          var (tranlatorExist, status) = _translatorRepository.IsExist(id);
            return tranlatorExist;
        }
    }
}
