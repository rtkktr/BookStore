using BookStore.Application.Dtos.AuthorDtos;

namespace BookStore.Application.Contracts
{
    public interface IAuthorService : ICompleteBaseService<CreateAuthorDto, EditAuthorDto, RemoveAuthorDto, GetAllAuthorDto, GetAuthorDto, ExistAuthorDto> { }
}