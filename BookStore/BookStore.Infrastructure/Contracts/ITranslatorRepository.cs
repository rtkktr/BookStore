using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface ITranslatorRepository<TKey, TExist, TStatus> : IBaseRepository<Translator?, TKey, TExist, TStatus> { }
}
