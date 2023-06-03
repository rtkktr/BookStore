using BookStore.Saas.Domain.Models;

namespace BookStore.Saas.Infrastructure.Contracts
{
    public interface IAuthorRepository<Tkey, TExist, TStatus> : IBaseRepository<Author?,Tkey,TExist, TStatus>
    {

    }
}