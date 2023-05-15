namespace BookStore.Infrastructure.Contracts
{
    public interface IBaseRepository<TEntity, TKey, TExist>
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(TKey id);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> SelectAllAsync();
        Task<TEntity> SelectByIdAsync(TKey id);
        Task<TExist> IsExist(TKey id);
    }
}