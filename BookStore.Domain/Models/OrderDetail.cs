namespace BookStore.Domain.Models;

public class OrderDetail
{
    public Guid OrderHeaderId { get; set; }
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public int Price { get { return Quantity * UnitPrice; } }

    public OrderHeader? OrderHeader { get; set; }
    public Book? Book { get; set; }
}
