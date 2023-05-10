using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public int AuthorId { get; set; }
        public int TranslatorId { get; set; }
        public int PublisherId { get; set; }

        public int ProductCode { get; set; }
        public string? Title { get; set; }
        public int PublishYear { get; set; }
        public int PageNumber { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public int Weight { get; set; }
        public int UnitPrice { get; set; }


        #region Relations

        public Author? Author { get; set; }
        public Translator? Translator { get; set; }
        public Publisher? Publisher { get; set; }

        #endregion
    }
}