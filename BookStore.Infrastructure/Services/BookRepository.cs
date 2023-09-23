using BookStore.Domain.Models.BookAggregates;
using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;

namespace BookStore.Infrastructure.Services
{
    public class BookRepository : IBookRepository
    {
        #region [- Constructor -]

        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region [- Delete -]

        public async Task<IEnumerable<ValidationError?>?> DeleteAsync(Book? entity)
        {
            
        }
        public Task<IEnumerable<ValidationError?>?> DeleteByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [- Insert -]

        public Task<IEnumerable<ValidationError?>?> InsertAsync(Book? entity)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ValidationError?>?> InsertRangeAsync(IEnumerable<Book?>? entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [- Is Exist -]

        public Task<(bool, IEnumerable<ValidationError?>?)> IsExist(Book? entity)
        {
            throw new NotImplementedException();
        }
        public Task<(bool, IEnumerable<ValidationError?>?)> IsExistById(Guid? id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [- Select -]

        public Task<(IEnumerable<Book?>?, IEnumerable<ValidationError?>?)> SelectAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<(Book?, IEnumerable<ValidationError?>?)> SelectAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [- Update -]

        public Task<IEnumerable<ValidationError?>?> UpdateAsync(Book? entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}