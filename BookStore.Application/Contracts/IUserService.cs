using BookStore.Application.Dtos.UserDtos;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Contracts
{
    public interface IUserService
    {
        Task<List<ValidationError?>?> CreateAsync(CreateUserDto user);
        Task<(List<GetAllUserDto?>?, List<ValidationError?>?)> GetAllAsync();
        Task<List<ValidationError?>?> RemoveAsync(RemoveUserDto removeUserDto);
        Task<(GetUserDto, List<ValidationError?>?)> GetUserByIdAsync(string id);
        Task<List<ValidationError?>?> EditAsync(EditUserDto editUserDto);
    }
}