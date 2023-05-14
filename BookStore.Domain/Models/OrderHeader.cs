using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class OrderHeader : BaseEntity
    {
        public int UserId { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        #region Relations

        public User? User { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        #endregion
    }
}
