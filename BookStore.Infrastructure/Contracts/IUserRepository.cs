using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IUserRepository<TKey, TExist> : IBaseRepository<User?, TKey, TExist> { }
}
