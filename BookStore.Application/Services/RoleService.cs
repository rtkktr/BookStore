using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Role;
using BookStore.Application.Dtos.Users;
using BookStore.Domain.Models;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<ValidationError?>?> CreateAsync(CreateRoleDto roleDto)
        {
            var role = new ApplicationRole()
            {
                Name = roleDto.Name,
            };
            List<IdentityError?>? errors = new List<IdentityError?>();
            List<ValidationError?>? validationErrors = new();
            if (role == null)
                errors.Add(new IdentityError() { Code = "NullRoleExeption", Description = "Role shoulden't be null " });


            if (role != null)
            {
                var result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    errors.AddRange(result.Errors.ToList());
                }
            }

            if(errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    validationErrors.Add(new ValidationError
                    {
                        Code = error.Code,
                        Description = error.Description,
                    });
                }
            }
            return validationErrors;

        }

        public async Task<(List<GetAllRoleDto?>?, List<ValidationError?>?)> GetAllAsync()
        {

            List<ValidationError?>? errors = new();

            List<ApplicationRole> roles = await _roleManager.Roles.ToListAsync();
            
            List<GetAllRoleDto> ? rolesDto = new List<GetAllRoleDto>();
            if (roles.Count == 0)
                errors.Add(new ValidationError
                {
                    Code = "RolesNotFound",
                    Description = "There are no role in the app"
                });

            foreach (var role in roles)
            {
                rolesDto.Add(new GetAllRoleDto
                {
                    Name = role.Name,
                    Id = role.Name
                });
            }

            return (rolesDto, errors);
        }
    }
}
