using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class OrderHeader : BaseEntity
    {
        public int UserId { get; set; }

        public string? Code { get; set; }
        public DateTime? Date { get; set; }

        #region Relations

        public User? User { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        #endregion
    }
}
