using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? StreetAddress { get; set; }

    }
}
