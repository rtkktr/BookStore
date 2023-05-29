using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Services
{
    public class BookRepository : IBookRepository<Guid, bool, BookRepositoryStatus>
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context) =>_context = context;

        public async Task<BookRepositoryStatus> DeleteAsync(Book? entity)
        {
            try
            {
                if (entity == null)
                    return BookRepositoryStatus.NullEntity;
                entity.IsDeleted = true;
                _context.Book.Update(entity);
                await _context.SaveChangesAsync();
                return BookRepositoryStatus.Success;
                
            }
            catch (Exception)
            {
                return BookRepositoryStatus.DatabaseError;
            }
        }

        public async Task<BookRepositoryStatus> DeleteByIdAsync(Guid id)
        {
            try
            {
                var book = await _context.Book.FirstOrDefaultAsync(book => book.Id == id);
                if (book == null) return BookRepositoryStatus.NullEntity;
                book.IsDeleted = true;
                _context.Book.Update(book);
                await _context.SaveChangesAsync();
                return BookRepositoryStatus.Success;
            }
            catch (Exception)
            {
                return BookRepositoryStatus.DatabaseError;
            }
        }

        public async Task<BookRepositoryStatus> InsertAsync(Book? entity)
        {
            try
            {
                if (entity == null)
                    return BookRepositoryStatus.NullEntity;
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return BookRepositoryStatus.Success;
            }
            catch (Exception)
            {
                return BookRepositoryStatus.DatabaseError;
            }
            

        }

        public (bool, BookRepositoryStatus) IsExist(Guid id)
        {
            try
            {
                bool isExist = (_context.Book?.Any(book => book.Id == id)).GetValueOrDefault();
                return (isExist, BookRepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, BookRepositoryStatus.BookNotExist);
            }
        }

        public async Task<(IEnumerable<Book?>?, BookRepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var books = await _context.Book.ToListAsync();
                if (books == null || books.Count == 0)
                    return (null, BookRepositoryStatus.TableIsEmpty);
                return (books, BookRepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, BookRepositoryStatus.DatabaseError);
            }
        }

        public async Task<(Book?, BookRepositoryStatus)> SelectByIdAsync(Guid id)
        {
            try
            {
                var book = await _context.Book.FirstOrDefaultAsync(book => book.Id == id);
                if (book == null)
                    return(null, BookRepositoryStatus.BookNotExist);
                return (book, BookRepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, BookRepositoryStatus.DatabaseError);
            }
        }

        public async Task<BookRepositoryStatus> UpdateAsync(Book? entity)
        {
            try
            {
                if (entity == null)
                    return BookRepositoryStatus.NullEntity;
                _context.Book.Update(entity);
                await _context.SaveChangesAsync();
                return BookRepositoryStatus.Success;

            }
            catch (Exception)
            {
                return BookRepositoryStatus.DatabaseError;
            }
        }
    }
}