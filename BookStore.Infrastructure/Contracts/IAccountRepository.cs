using BookStore.Utility.ValidationErrors;

namespace BookStore.Infrastructure.Contracts
{
    public interface IAccountRepository
    {
        Task<List<ValidationError?>?> SignInAsync(string? username, string? password);
        Task Logout();
    }
}