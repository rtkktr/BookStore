using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface ITranslatorRepository<TKey, TExist> : IBaseRepository<Translator?, TKey, TExist> { }
}
