using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Commons
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
