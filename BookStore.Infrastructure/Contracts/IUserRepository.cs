using BookStore.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Contracts
{
    public interface IUserRepository<TStatus>
    {
        Task<TStatus> InsertAsync(IdentityUser? entity, string? password);
    }
}
