using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Services
{
    public class UserRepository : IUserRepository<List<IdentityError>?>
    {
        #region [- Constructor -]

        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        #endregion
        public async Task<List<IdentityError>?> InsertAsync(IdentityUser? entity, string? password)
        {
            if (entity == null)
                return new List<IdentityError> { new IdentityError { Code = "NullEntity", Description = "Entity is null." } };

            if (password == null)
                return new List<IdentityError> { new IdentityError { Code = "NullPassword", Description = "Password is null." } };

            var result = await _userManager.CreateAsync(entity, password);

            if (!result.Succeeded)
                return (List<IdentityError>)result.Errors;

            return null;
        }
    }
}
