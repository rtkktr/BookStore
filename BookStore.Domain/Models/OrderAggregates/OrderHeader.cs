using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Models.OrderAggregates;

public class OrderHeader : BaseEntity
{
    public string? Code { get; set; }
    public DateTime? Date { get; set; }


    public IdentityUser? User { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }
}
