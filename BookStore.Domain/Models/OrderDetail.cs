using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderHeaderId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Price { get { return Quantity * UnitPrice; } }

        #region Relations

        public OrderHeader? OrderHeader { get; set; }
        public Book? Book { get; set; }

        #endregion
    }
}
