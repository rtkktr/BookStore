using BookStore.Domain.Models.AuthorAggregates;
using BookStore.Infrastructure.Contracts;
using BookStore.Utility.ValidationErrors;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        #region [- Constructor -]

        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region [- Delete -]

        public async Task<IEnumerable<ValidationError?>?> DeleteAsync(Author? entity)
        {
            List<ValidationError?>? errors = new();

            if (entity == null)
            {
                errors.Add(new ValidationError { Code = "NullAuthorException", Description = "Author shouldn't be null" });
                return errors;
            }

            try
            {
                _context.Author.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }

            return errors;
        }
        public async Task<IEnumerable<ValidationError?>?> DeleteByIdAsync(Guid? id)
        {
            List<ValidationError?>? errors = new();

            if (id == null)
            {
                errors.Add(new ValidationError { Code = "NullIdException", Description = "Id shouldn't be null" });
                return errors;
            }

            var (author, selectErrors) = await SelectAsync(id);

            if (author == null)
            {
                if (selectErrors != null)
                    errors.AddRange(selectErrors);
                return errors;
            }

            var deleteErrors = await DeleteAsync(author);

            if (deleteErrors != null)
                errors.AddRange(deleteErrors);

            return errors;
        }

        #endregion

        #region [- Insert -]

        public async Task<IEnumerable<ValidationError?>?> InsertAsync(Author? entity)
        {
            List<ValidationError?>? errors = new();

            if (entity == null)
            {
                errors.Add(new ValidationError { Code = "NullAuthorException", Description = "Author shouldn't be null" });
                return errors;
            }

            try
            {
                await _context.Author.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }

            return errors;
        }
        public async Task<IEnumerable<ValidationError?>?> InsertRangeAsync(IEnumerable<Author?>? entities)
        {
            List<ValidationError?>? errors = new();

            if (entities == null)
            {
                errors.Add(new ValidationError { Code = "NullCollectionException", Description = "Collection shouldn't be null" });
                return errors;
            }

            List<Author> authors = new();
            int index = 0;
            foreach (var item in entities)
            {
                if (item == null)
                    errors.Add(new ValidationError { Code = "NullAuthorException", Description = $"Author in index {index} is null" });
                else
                    authors.Add(item);
                index++;
            }

            try
            {
                await _context.Author.AddRangeAsync(authors);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }

            return errors;
        }

        #endregion

        #region [- Select -]

        public async Task<(IEnumerable<Author?>?, IEnumerable<ValidationError?>?)> SelectAllAsync()
        {
            List<ValidationError?>? errors = new();
            List<Author>? authors = new();

            try
            {
                authors = await _context.Author.ToListAsync();
                if (!authors.Any())
                {
                    errors.Add(new ValidationError { Code = "NullAuthorFound", Description = "There are no author in the app" });
                }
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }

            return (authors, errors);
        }
        public async Task<(Author?, IEnumerable<ValidationError?>?)> SelectAsync(Guid? id)
        {
            List<ValidationError?>? errors = new();
            Author? author = new();

            try
            {
                author = await _context.Author.FirstOrDefaultAsync(author => author.Id == id);
                if (author == null)
                {
                    errors.Add(new ValidationError { Code = "AuthorNotFound", Description = "Author couldn't be found" });
                }
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }

            return (author, errors);
        }

        #endregion

        #region [- Update -]

        public async Task<IEnumerable<ValidationError?>?> UpdateAsync(Author? entity)
        {
            List<ValidationError?>? errors = new();

            if (entity == null)
            {
                errors.Add(new ValidationError { Code = "NullAuthorException", Description = "Author shouldn't be null" });
                return errors;
            }

            try
            {
                _context.Author.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }

            return errors;
        }

        #endregion

        #region [- IsExist -]

        public async Task<(bool, IEnumerable<ValidationError?>?)> IsExist(Author? entity)
        {
            List<ValidationError?>? errors = new();

            if (entity == null)
            {
                errors.Add(new ValidationError { Code = "NullAuthorException", Description = "Author shouldn't be null" });
                return (false, errors);
            }

            try
            {
                if (await _context.Author.AnyAsync(e => e.Id == entity.Id))
                    return(true, null);
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }
            return (false, errors);

        }
        public async Task<(bool, IEnumerable<ValidationError?>?)> IsExistById(Guid? id)
        {
            List<ValidationError?>? errors = new();

            if (id == null)
            {
                errors.Add(new ValidationError { Code = "NullIdException", Description = "Id shouldn't be null" });
                return (false, errors);
            }

            try
            {
                if (await _context.Author.AnyAsync(e => e.Id == id))
                    return (true, null);
            }
            catch (Exception e)
            {
                errors.Add(new ValidationError { Code = e.Message, Description = e.StackTrace });
            }
            return (false, errors);
        }

        #endregion
    }
}