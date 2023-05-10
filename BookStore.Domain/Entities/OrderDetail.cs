using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderHeaderId { get; set; }
        public int BookId { get; set; }

        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Price { get { return Quantity * UnitPrice; } }

        #region Relations

        public OrderHeader? OrderHeader { get; set; }
        public Book? Book { get; set; }

        #endregion
    }
}
