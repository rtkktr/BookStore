namespace BookStore.Infrastructure.Contracts
{
    public interface IBaseRepository<TEntity, TKey, TExist, TStatus>
    {
        Task<TStatus> InsertAsync(TEntity entity);
        Task<TStatus> UpdateAsync(TEntity entity);
        Task<TStatus> DeleteByIdAsync(TKey id);
        Task<TStatus> DeleteAsync(TEntity entity);
        Task<(IEnumerable<TEntity>?, TStatus)> SelectAllAsync();
        Task<(TEntity, TStatus)> SelectByIdAsync(TKey id);
        (TExist, TStatus) IsExist(TKey id);
    }
}