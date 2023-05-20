using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class OrderHeader : BaseEntity
    {
        public Guid UserId { get; set; }

        public string? Code { get; set; }
        public DateTime? Date { get; set; }

        #region Relations

        public User? User { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        #endregion
    }
}
