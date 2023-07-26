using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IAuthorRepository<Tkey, TExist, TStatus> : IBaseRepository<Author?,Tkey,TExist, TStatus>
    {

    }
}
