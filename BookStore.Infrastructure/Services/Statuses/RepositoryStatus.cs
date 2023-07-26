namespace BookStore.Infrastructure.Services.Statuses
{
    public enum RepositoryStatus
    {
        NullEntity,
        Success,
        DatabaseError,
        NotExist,
        TableIsEmpty
    }
}
