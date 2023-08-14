using System.ComponentModel.DataAnnotations;

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
    }
}
