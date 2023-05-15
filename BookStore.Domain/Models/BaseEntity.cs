using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}