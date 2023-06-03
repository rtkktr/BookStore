namespace BookStore.Saas.Infrastructure.Services.Statuses
{
    public enum RepositoryStatus
    {
        NullEntity,
        Success,
        DatabaseError,
        BookNotExist,
        TableIsEmpty
    }
}