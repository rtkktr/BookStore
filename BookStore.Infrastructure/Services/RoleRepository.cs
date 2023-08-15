using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore.Infrastructure.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<ValidationError?>?> InsertAsync(IdentityRole? role)
        {

            List<IdentityError?>? errors = new List<IdentityError?>();

            if (role == null)
                errors.Add(new IdentityError() { Code = "NullRoleExeption", Description = "Role shoulden't be null " });


            if (role != null)
            {
                var result = await _roleManager.CreateAsync(role);
                errors.AddRange(result.Errors.ToList());
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

        public async Task<(List<IdentityRole>, List<ValidationError?>?)> SelectAllAsync()
        {
            List<ValidationError?>? errors = new();

            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();

            if (roles.Count == 0)
                errors.Add(new ValidationError
                {
                    Code = "RolesNotFound",
                    Description = "There are no role in the app"
                });
            return (roles, errors);
        }
    }
}