using BookStore.Application.Dtos.AuthorDtos;
using BookStore.Application.Dtos.UserDtos;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Contracts
{
    public interface IAuthorService
    {
        Task<List<ValidationError?>?> CreateAsync(CreateAuthorDto author);
        Task<(List<GetAllAuthorDto?>?, List<ValidationError?>?)> GetAllAsync();
        Task<List<ValidationError?>?> RemoveAsync(RemoveAuthorDto removeAuthorDto);
        Task<(GetAuthorDto, List<ValidationError?>?)> GetAuthorByIdAsync(string id);
        Task<List<ValidationError?>?> EditAsync(EditAuthorDto editAuthorDto);
    }
}