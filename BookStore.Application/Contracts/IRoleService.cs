using BookStore.Application.Dtos.Role;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Contracts
{
    public interface IRoleService
    {
        Task<List<ValidationError?>?> CreateAsync(CreateRoleDto role);
        Task<(List<GetAllRoleDto?>?, List<ValidationError?>?)> GetAllAsync();
    }
}
