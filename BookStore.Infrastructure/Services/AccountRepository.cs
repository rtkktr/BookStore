using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<List<ValidationError?>?> SignInAsync(string? username, string? password)
        {
            List<ValidationError?>? errors = new();

            if (username == null)
                errors.Add(new ValidationError() { Code = "NullUsernameExeption", Description = "Username shoulden't be null " });

            if (password == null)
                errors.Add(new ValidationError() { Code = "NullPasswordExeption", Description = "Password shoulden't be null " });

            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (!result.Succeeded)
                errors.Add(new ValidationError() { Code = "NotFound", Description = "Invalid UserName or Password!" });

            return errors;
        }
    }
}