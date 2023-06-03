namespace BookStore.Saas.Domain.Models;

public class Publisher : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }
    public bool IsDeleted { get; set; }

    public List<Book>? Books { get; set; }
}
