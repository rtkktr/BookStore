using BookStore.Application.Dtos.Users;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Contracts
{
    public interface IUserService
    {
        Task<List<ValidationError?>?> CreateAsync(CreateUserDto user);
        Task<(List<GetAllUserDto?>?, List<ValidationError?>?)> GetAllAsync();
        Task<List<ValidationError?>?> RemoveById(RemoveUserDto removeUserDto);
        Task<(GetUserDto, List<ValidationError?>?)> GetUserById(string id);
        Task<List<ValidationError?>?> EditById(EditUserDto editUserDto);
    }
}