using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Name { get; set; }
    }
}
