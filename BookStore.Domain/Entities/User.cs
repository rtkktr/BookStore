using BookStore.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(150)]
        [Required]
        public string? FirstName { get; set; }

        [MaxLength(150)]
        public string? LastName { get; set; }


        [Required]
        [RegularExpression(@"^0[0-9]{10}$")]
        public string? PhoneNumber { get; set; }

        [RegularExpression("^\\S+@\\S+\\.\\S+$")]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$")]
        public string? NationalId { get; set; }

        #region Relations

        public List<OrderHeader>? OrderHeaders { get; set; }

        #endregion
    }
}
