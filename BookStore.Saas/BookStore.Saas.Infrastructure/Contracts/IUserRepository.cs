using BookStore.Saas.Domain.Models;

namespace BookStore.Saas.Infrastructure.Contracts
{
    public interface IUserRepository<TKey, TExist, TStatus> : IBaseRepository<User?, TKey, TExist, TStatus> { }
}
