using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class UserController : Controller
    {
        #region [- Constructor -]

        private readonly IUserService<List<IdentityError>> _userService;

        public UserController(IUserService<List<IdentityError>> userService)
        {
            _userService = userService;
        }

        #endregion

        #region [- Index -]

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        #endregion

        #region [- Register -]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

        #endregion
    }
}