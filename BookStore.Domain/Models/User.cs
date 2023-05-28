namespace BookStore.Domain.Models;

public class User : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? NationalId { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }
    public bool IsDeleted { get; set; }

    public List<OrderHeader>? OrderHeaders { get; set; }
}