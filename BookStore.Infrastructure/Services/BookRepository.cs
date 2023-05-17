using BookStore.Infrastructure;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Services
{
    public class BookRepository : IBookRepository<Guid?, bool?>
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Book? entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Book? entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<bool?> IsExist(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book?>> SelectAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public Task<Book?> SelectByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book? entity)
        {
            throw new NotImplementedException();
        }
    }
}
