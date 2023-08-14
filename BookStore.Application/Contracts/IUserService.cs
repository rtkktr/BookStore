using BookStore.Application.Dtos.Users;

namespace BookStore.Application.Contracts
{
    public interface IUserService<TStatus>
    {
        Task<TStatus> CreateAsync(CreateUserDto entity);
    }

}
