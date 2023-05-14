using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class Publisher : BaseEntity
    {
        [MaxLength(300)]
        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        #region Relations

        public List<Book>? Books { get; set; }

        #endregion
    }
}
