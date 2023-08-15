using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Users;
using BookStore.Infrastructure.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Presentation.Controllers
{
    public class UserController : Controller
    {
        #region [- Constructor -]

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region [- Index -]

        public async Task<IActionResult> Index()
        {
            var (users, errors) = await _userService.GetAllAsync();
            if (errors != null)
                foreach (var e in errors)
                    if (e != null && e.Description != null)
                        ModelState.AddModelError("", e.Description);
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
                var result = await _userService.CreateAsync(createUserDto);
                if (result == null || result.Count == 0)
                    return RedirectToAction("Index", "User");
                else
                {
                    foreach (var e in result)
                    {
                        if (e != null && e.Description != null)
                            ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View(createUserDto);
        }

        #endregion
    }
}