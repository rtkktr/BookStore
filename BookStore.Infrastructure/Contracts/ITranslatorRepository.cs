using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface ITranslatorRepository<TKey> : IBaseRepository<Translator, TKey> { }
}
