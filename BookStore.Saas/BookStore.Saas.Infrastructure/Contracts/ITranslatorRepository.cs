using BookStore.Saas.Domain.Models;

namespace BookStore.Saas.Infrastructure.Contracts
{
    public interface ITranslatorRepository<TKey, TExist, TStatus> : IBaseRepository<Translator?, TKey, TExist, TStatus> { }
}
