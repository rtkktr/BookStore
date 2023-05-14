namespace BookStore.Infrastructure.Contracts
{
    public interface IBaseRepository<TEntity, TKey>
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> SelectAllAsync();
        Task<TEntity> SelectByIdAsync(TKey id);
    }
}