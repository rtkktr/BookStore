using BookStore.Domain.Commons;

namespace BookStore.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? NationalId { get; set; }

        #region Relations

        public List<OrderHeader>? OrderHeaders { get; set; }

        #endregion
    }
}
