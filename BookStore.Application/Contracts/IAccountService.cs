using BookStore.Application.Dtos.AccountDtos;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Contracts
{
    public interface IAccountService
    {
        Task<List<ValidationError?>?> SignInAsync(LoginDto login);
        Task Logout();
    }
}