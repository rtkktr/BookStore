using BookStore.Application.Contracts;
using BookStore.Application.Dtos.AuthorDtos;
using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<List<ValidationError?>?> CreateAsync(CreateAuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Task<List<ValidationError?>?> EditAsync(EditAuthorDto editAuthorDto)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<GetAllAuthorDto?>?, List<ValidationError?>?)> GetAllAsync()
        {
            var (authors, errors) = await _authorRepository.SelectAllAsync();

            List<GetAllAuthorDto?>? getAllAuthorDtos = new();

            foreach (var item in authors)
            {
                getAllAuthorDtos.Add(new GetAllAuthorDto
                {
                    Id = item.Id,
                    Name = $"{item.FirstName} {item.LastName}",
                    Description = item.Description
                });
            }

            return (getAllAuthorDtos, errors);
        }

        public Task<(GetAuthorDto, List<ValidationError?>?)> GetAuthorByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ValidationError?>?> RemoveAsync(RemoveAuthorDto removeAuthorDto)
        {
            throw new NotImplementedException();
        }
    }
}