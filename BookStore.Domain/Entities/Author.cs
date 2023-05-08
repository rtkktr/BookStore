using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        #region Relations

        public List<Book>? Books { get; set; }

        #endregion
    }
}