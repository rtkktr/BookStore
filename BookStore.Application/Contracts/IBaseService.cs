namespace BookStore.Application.Contracts
{
    public interface IBaseService<TCreateEntity, TEditEntity, TRemoveEntity, TGetAllEntity, TGetEntity, TExistEntity, TError, TId, TExist>
    {
        Task<IEnumerable<TError?>?> CreateAsync(TCreateEntity? entity);
        Task<IEnumerable<TError?>?> CreateRangeAsync(IEnumerable<TCreateEntity?>? entities);
        Task<IEnumerable<TError?>?> EditAsync(TEditEntity? entity);
        Task<IEnumerable<TError?>?> RemoveAsync(TRemoveEntity? entity);
        Task<IEnumerable<TError?>?> RemoveByIdAsync(TId? id);
        Task<(IEnumerable<TGetAllEntity?>?, IEnumerable<TError?>?)> GetAllAsync();
        Task<(TGetEntity?, IEnumerable<TError?>?)> GetAsync(TId? id);
        Task<(TExist, IEnumerable<TError?>?)> IsExist(TExistEntity? entity);
        Task<(TExist, IEnumerable<TError?>?)> IsExistById(TId? id);
    }
}