using BookStore.Domain.Models.TranslatorAggregates;

namespace BookStore.Infrastructure.Contracts
{
    public interface ITranslatorRepository : ICompleteBaseRepository<Translator> { }
}