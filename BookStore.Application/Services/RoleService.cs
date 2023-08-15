using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Role;
using BookStore.Application.Dtos.Users;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<ValidationError?>?> CreateAsync(CreateRoleDto role)
        {

            var identityRole = new IdentityRole
            {
                Name = role.Name
            };

            var results = await _roleRepository.InsertAsync(identityRole);

            return results;

        }

        public async Task<(List<GetAllRoleDto?>?, List<ValidationError?>?)> GetAllAsync()
        {
            List<GetAllRoleDto?>? roles = new List<GetAllRoleDto?>();

            var (identityRoles, errors) = await _roleRepository.SelectAllAsync();

            foreach (var role in identityRoles)
            {
                roles.Add(new GetAllRoleDto
                {
                    Name = role.Name,
                    Id = role.Name
                });
            }

            return (roles, errors);
        }
    }
}
