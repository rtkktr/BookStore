namespace BookStore.Saas.Domain.Models;

public class OrderHeader : BaseEntity
{
    public string? Code { get; set; }
    public DateTime? Date { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }
    public bool IsDeleted { get; set; }


    public User? User { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }
}
