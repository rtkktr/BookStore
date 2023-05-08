using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public int Price { get; set; }
    }
}