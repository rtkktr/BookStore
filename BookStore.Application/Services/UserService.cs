using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Users;
using BookStore.Infrastructure.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Application.Services
{
    public class UserService : IUserService<List<IdentityError>?>
    {
        private readonly IUserRepository<List<IdentityError>> _userRepository;

        public UserService(IUserRepository<List<IdentityError>> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<IdentityError>?> CreateAsync(CreateUserDto entity)
        {
            var user = new IdentityUser()
            {
                UserName = entity.UserName,
                Email = entity.Email,
            };

            var result = _userRepository.InsertAsync(user, entity.Password);

            return result;
        }
    }
}
