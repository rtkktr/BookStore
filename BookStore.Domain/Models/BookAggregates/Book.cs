using BookStore.Domain.Models.AuthorAggregates;
using BookStore.Domain.Models.PublisherAggregates;
using BookStore.Domain.Models.TranslatorAggregates;

namespace BookStore.Domain.Models.BookAggregates;

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

    public List<Author>? Authors { get; set; }
    public List<Translator>? Translators { get; set; }
    public Publisher? Publisher { get; set; }
}