using BookStore.Domain.Models.BookAggregates;

namespace BookStore.Domain.Models.AuthorAggregates;

public class Author : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }

    public List<Book>? Books { get; set; }
}