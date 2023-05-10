using BookStore.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderHeaderId { get; set; }
        public int BookId { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public int UnitPrice { get; set; }

        public int Price { get { return Quantity * UnitPrice; } }

        #region Relations

        public OrderHeader? OrderHeader { get; set; }
        public Book? Book { get; set; }

        #endregion
    }
}
