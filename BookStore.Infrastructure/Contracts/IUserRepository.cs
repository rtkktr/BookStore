using BookStore.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Contracts
{
    public interface IUserRepository<TKey, TExist, TStatus> : IBaseRepository<IdentityUser?, TKey, TExist, TStatus> { }
}
