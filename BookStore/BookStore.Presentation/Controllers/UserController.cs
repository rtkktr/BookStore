using BookStore.Domain.Models;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository<Guid?, bool, RepositoryStatus> _userRepository;

        public UserController(IUserRepository<Guid?, bool, RepositoryStatus> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var (users, usersStatus) = await _userRepository.SelectAllAsync();
            switch (usersStatus)
            {
                case RepositoryStatus.Success:
                    return View(users);
                case RepositoryStatus.DatabaseError:
                case RepositoryStatus.TableIsEmpty: 
                    return View(new List<User>());
            }
            return View();
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var (users, usersStatus) = await _userRepository.SelectAllAsync();
            if (id == null || User == null)
            {
                return NotFound();
            }

            var (user, userStatus) = await _userRepository.SelectByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,PhoneNumber,Email,Username,Password,NationalId,DateCreation,DateModification,IsDeleted,Id")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                await _userRepository.InsertAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var (users, usersStatus) = await _userRepository.SelectAllAsync();
            if (id == null || users == null)
            {
                return NotFound();
            }

            var (user, userStatus) = await _userRepository.SelectByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName,LastName,PhoneNumber,Email,Username,Password,NationalId,DateCreation,DateModification,IsDeleted,Id")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var (users, usersStatus) = await _userRepository.SelectAllAsync();
            if (id == null || users == null)
            {
                return NotFound();
            }

            var (user, userStatus) = await _userRepository.SelectByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var (users, usersStatus) = await _userRepository.SelectAllAsync();
            if (users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            var (user, userStatus) = await _userRepository.SelectByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            var(userExist, status) = _userRepository.IsExist(id);
            return userExist;
        }
    }
}
