using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Contracts
{
    public interface IRoleRepository
    {
        Task<List<ValidationError?>?> InsertAsync(IdentityRole? role);
        Task<(List<IdentityRole>, List<ValidationError?>?)> SelectAllAsync();
    }
}