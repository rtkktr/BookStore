using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Services
{
    public class PublisherRepository : IPublisherRepository<Guid?, bool, RepositoryStatus>
    {
        private readonly ApplicationDbContext _context;

        public PublisherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryStatus> DeleteAsync(Publisher? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                entity.IsDeleted = true;
                _context.Publisher.Update(entity);
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
                var publisher = await _context.Publisher.FirstOrDefaultAsync(publisher => publisher.Id == id);
                if (publisher == null) return RepositoryStatus.NullEntity;
                publisher.IsDeleted = true;
                _context.Publisher.Update(publisher);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(Publisher? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.Publisher.AddAsync(entity);
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
                bool isExist = (_context.Publisher?.Any(author => author.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<Publisher?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var publisher = await _context.Publisher.ToListAsync();
                if (publisher == null || publisher.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (publisher, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(Publisher?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var publisher = await _context.Publisher.FirstOrDefaultAsync(publisher => publisher.Id == id);
                if (publisher == null)
                    return (null, RepositoryStatus.NotExist);
                return (publisher, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(Publisher? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                _context.Publisher.Update(entity);
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
