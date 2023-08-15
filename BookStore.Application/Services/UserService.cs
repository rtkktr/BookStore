using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Users;
using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ValidationError?>?> CreateAsync(CreateUserDto user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email,
            };

            var results = await _userRepository.InsertAsync(identityUser, user.Password);

            return results;
        }

        public async Task<(List<GetAllUserDto?>?, List<ValidationError?>?)> GetAllAsync()
        {
            List<GetAllUserDto?>? users = new List<GetAllUserDto?>();

            var (identityUsers, errors) = await _userRepository.SelectAllAsync();

            foreach (var user in identityUsers)
            {
                users.Add(new GetAllUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Id = user.Id
                });
            }

            return (users, errors);
        }
    }
}