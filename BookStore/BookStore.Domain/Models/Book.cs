namespace BookStore.Domain.Models;

public class Book : BaseEntity
{
    public int ProductCode { get; set; }
    public string? Title { get; set; }
    public int PublishYear { get; set; }
    public int PageNumber { get; set; }
    public string? ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public int Weight { get; set; }
    public int UnitPrice { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }
    public bool IsDeleted { get; set; }

    public List<Author>? Authors { get; set; }
    public List<User>? Translators { get; set; }
    public Publisher? Publisher { get; set; }
}