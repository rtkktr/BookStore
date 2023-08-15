using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        Task<List<ValidationError?>?> InsertAsync(IdentityUser? user, string? password);
        Task<(List<IdentityUser>, List<ValidationError?>?)> SelectAllAsync();
    }
}