using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string? Title { get; set; }

        public List<Book>? Books { get; set; }

    }
}
