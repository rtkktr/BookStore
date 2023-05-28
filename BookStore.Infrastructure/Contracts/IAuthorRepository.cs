using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IAuthorRepository<Tkey, TExist> : IBaseRepository<Author?,Tkey,TExist>
    {

    }
}
