namespace BookStore.Infrastructure.Services.Statuses
{
    public enum BookRepositoryStatus
    {
        NullEntity,
        Success,
        DatabaseError,
        BookNotExist,
        TableIsEmpty
    }
}