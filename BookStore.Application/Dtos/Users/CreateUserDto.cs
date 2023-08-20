using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Application.Dtos.Users
{
    public class CreateUserDto
    {
        [Required]
        public string? UserName { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DisplayName("Name")]
        public string? FirstName { get; set; }
        
        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{10}$")]
        [DisplayName("National id")]
        public string? NatinalCode { get; set; }
        
        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression(@"^09\d{9}$")]
        public string? PhoneNumber { get; set; }


    }
}
