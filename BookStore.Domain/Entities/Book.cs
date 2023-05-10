using BookStore.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public int AuthorId { get; set; }
        public int TranslatorId { get; set; }
        public int PublisherId { get; set; }

        [Required]
        public int ProductCode { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Title { get; set; }

        [Required]
        public int PublishYear { get; set; }

        public int PageNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public int Weight { get; set; }

        [Required]
        public int UnitPrice { get; set; }


        #region Relations

        public Author? Author { get; set; }
        public Translator? Translator { get; set; }
        public Publisher? Publisher { get; set; }

        #endregion
    }
}