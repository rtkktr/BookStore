using BookStore.Utility.ValidationErrors;

namespace BookStore.Infrastructure.Contracts
{
    public interface ICompleteBaseRepository<TEntity> : IBaseRepository<TEntity, ValidationError, Guid?, bool> { }
}
