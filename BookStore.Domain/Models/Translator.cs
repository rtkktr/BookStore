using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class Translator : BaseEntity
    {
        [MaxLength(150)]
        [Required]
        public string? FirstName { get; set; }

        [MaxLength(150)]
        [Required]
        public string? LastName { get; set; }

        public string? Description { get; set; }

        #region Relations

        public List<Book>? Books { get; set; }

        #endregion
    }
}