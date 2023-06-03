using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Services
{
    public class AuthorRepository : IAuthorRepository<Guid?, bool, RepositoryStatus>
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryStatus> DeleteAsync(Author? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                entity.IsDeleted = true;
                _context.Author.Update(entity);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;

            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> DeleteByIdAsync(Guid? id)
        {
            try
            {
                var author = await _context.Author.FirstOrDefaultAsync(author => author.Id == id);
                if (author == null) return RepositoryStatus.NullEntity;
                author.IsDeleted = true;
                _context.Author.Update(author);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(Author? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.Author.AddAsync(entity);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public (bool, RepositoryStatus) IsExist(Guid? id)
        {
            try
            {
                bool isExist = (_context.Author?.Any(author => author.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<Author?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var authors = await _context.Author.ToListAsync();
                if (authors == null || authors.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (authors, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(Author?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var author = await _context.Author.FirstOrDefaultAsync(author => author.Id == id);
                if (author == null)
                    return (null, RepositoryStatus.NotExist);
                return (author, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(Author? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                _context.Author.Update(entity);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;

            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }
    }
}
