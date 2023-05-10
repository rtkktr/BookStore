using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class Translator : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }

        #region Relations

        public List<Book>? Books { get; set; }

        #endregion
    }
}