//using BookStore.Domain.Models;
//using BookStore.Infrastructure.Contracts;
//using BookStore.Infrastructure.Services.Statuses;
//using Microsoft.EntityFrameworkCore;

//namespace BookStore.Infrastructure.Services
//{
//    public class BookRepository : IBookRepository<Guid?, bool, RepositoryStatus>
//    {
//        private readonly ApplicationDbContext _context;

//        public BookRepository(ApplicationDbContext context) =>_context = context;

//        public async Task<RepositoryStatus> DeleteAsync(Book? entity)
//        {
//            try
//            {
//                if (entity == null)
//                    return RepositoryStatus.NullEntity;
//                entity.IsDeleted = true;
//                _context.Book.Update(entity);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;
                
//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
//        }

//        public async Task<RepositoryStatus> DeleteByIdAsync(Guid? id)
//        {
//            try
//            {
//                var book = await _context.Book.FirstOrDefaultAsync(book => book.Id == id);
//                if (book == null) return RepositoryStatus.NullEntity;
//                book.IsDeleted = true;
//                _context.Book.Update(book);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;
//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
//        }

//        public async Task<RepositoryStatus> InsertAsync(Book? entity)
//        {
//            try
//            {
//                if (entity == null)
//                    return RepositoryStatus.NullEntity;
//                await _context.Book.AddAsync(entity);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;
//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
            

//        }

//        public (bool, RepositoryStatus) IsExist(Guid? id)
//        {
//            try
//            {
//                bool isExist = (_context.Book?.Any(book => book.Id == id)).GetValueOrDefault();
//                return (isExist, RepositoryStatus.Success);
//            }
//            catch (Exception)
//            {
//                return (false, RepositoryStatus.NotExist);
//            }
//        }

//        public async Task<(IEnumerable<Book?>?, RepositoryStatus)> SelectAllAsync()
//        {
//            try
//            {
//                var books = await _context.Book.ToListAsync();
//                if (books == null || books.Count == 0)
//                    return (null, RepositoryStatus.TableIsEmpty);
//                return (books, RepositoryStatus.Success);
//            }
//            catch (Exception)
//            {
//                return (null, RepositoryStatus.DatabaseError);
//            }   
//        }

//        public async Task<(Book?, RepositoryStatus)> SelectByIdAsync(Guid? id)
//        {
//            try
//            {
//                var book = await _context.Book.FirstOrDefaultAsync(book => book.Id == id);
//                if (book == null)
//                    return(null, RepositoryStatus.NotExist);
//                return (book, RepositoryStatus.Success);
//            }
//            catch (Exception)
//            {
//                return (null, RepositoryStatus.DatabaseError);
//            }
//        }

//        public async Task<RepositoryStatus> UpdateAsync(Book? entity)
//        {
//            try
//            {
//                if (entity == null)
//                    return RepositoryStatus.NullEntity;
//                _context.Book.Update(entity);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;

//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
//        }
//    }
//}