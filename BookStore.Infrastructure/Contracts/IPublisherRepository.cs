using BookStore.Domain.Models.PublisherAggregates;

namespace BookStore.Infrastructure.Contracts
{
    public interface IPublisherRepository : ICompleteBaseRepository<Publisher> { }
}