namespace BookStore.Domain.Models;

public class Publisher : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }

    public List<Book>? Books { get; set; }
}
