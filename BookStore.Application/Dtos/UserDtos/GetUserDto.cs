﻿namespace BookStore.Application.Dtos.UserDtos
{
    public class GetUserDto
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalId { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? StreetAddress { get; set; }
        public string? Email { get; set; }
    }
}
