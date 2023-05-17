using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Models
{
    public class Book : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Guid TranslatorId { get; set; }
        public Guid PublisherId { get; set; }

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