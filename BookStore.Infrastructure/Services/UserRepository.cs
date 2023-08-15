using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        #region [- Constructor -]

        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        #endregion

        #region [- Insert -]

        public async Task<List<ValidationError?>?> InsertAsync(IdentityUser? user, string? password)
        {
            List<IdentityError?>? errors = new List<IdentityError?>();

            if (user == null)
                errors.Add(new IdentityError() { Code = "NullUserExeption", Description = "User shoulden't be null " });

            if (password == null)
                errors.Add(new IdentityError() { Code = "NullPasswordExeption", Description = "Password shoulden't be null " });

            if (user != null && password != null)
            {
                var result = await _userManager.CreateAsync(user, password);
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                errors.AddRange(result.Errors.ToList());
                errors.AddRange(roleResult.Errors.ToList());
            }

            List<ValidationError?>? validationErrors = new();

            foreach (var error in errors)
            {
                validationErrors.Add(new ValidationError
                {
                    Code = error.Code,
                    Description = error.Description,
                });
            }
            
            return validationErrors;
        }

        #endregion

        #region [- Select -]

        public async Task<(List<IdentityUser>, List<ValidationError?>?)> SelectAllAsync()
        {
            List<ValidationError?>? errors = new();

            List<IdentityUser> users = await _userManager.Users.ToListAsync();

            if (users.Count == 0)
                errors.Add(new ValidationError
                {
                    Code = "UsersNotFound",
                    Description = "There are no registered users in the app"
                });
            return (users, errors);
        }

        #endregion
    }
}