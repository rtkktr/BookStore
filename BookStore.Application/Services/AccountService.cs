using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Account;
using BookStore.Domain.Models;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<List<ValidationError?>?> SignInAsync(LoginDto login)
        {
            List<ValidationError?>? errors = new();

            if (login.UserName == null)
                errors.Add(new ValidationError() { Code = "NullUsernameExeption", Description = "Username shoulden't be null " });

            if (login.Password == null)
                errors.Add(new ValidationError() { Code = "NullPasswordExeption", Description = "Password shoulden't be null " });

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, true, false);

            if (!result.Succeeded)
                errors.Add(new ValidationError() { Code = "NotFound", Description = "Invalid UserName or Password!" });

            return errors;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
