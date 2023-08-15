using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                var errors = await _accountService.SignInAsync(login);

                if (errors == null || errors.Count == 0)
                    return RedirectToAction("Index", "Home");
                else
                    foreach (var e in errors)
                        if (e != null && e.Description != null)
                            ModelState.AddModelError("", e.Description);
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Redirect("/");
        }
    }
}
