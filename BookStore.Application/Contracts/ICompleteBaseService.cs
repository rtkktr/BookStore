using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Contracts
{
    public interface ICompleteBaseService<TCreateEntity, TEditEntity, TRemoveEntity, TGetAllEntity, TGetEntity, TExistEntity> : IBaseService<TCreateEntity, TEditEntity, TRemoveEntity, TGetAllEntity, TGetEntity, TExistEntity, ValidationError, Guid?, bool> { }
}