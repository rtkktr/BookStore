using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Account;
using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<ValidationError?>?> SignInAsync(LoginDto login)
        {
            var results = await _accountRepository.SignInAsync(login.UserName, login.Password);

            return results;
        }

        public async Task Logout()
        {
            await _accountRepository.Logout();
        }
    }
}
