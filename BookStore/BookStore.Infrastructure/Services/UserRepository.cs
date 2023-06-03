using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Services
{
    public class UserRepository : IUserRepository<Guid?, bool, RepositoryStatus>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryStatus> DeleteAsync(User? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                entity.IsDeleted = true;
                _context.User.Update(entity);
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
                var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null) return RepositoryStatus.NullEntity;
                user.IsDeleted = true;
                _context.User.Update(user);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(User? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.User.AddAsync(entity);
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
                bool isExist = (_context.User?.Any(u => u.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<User?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var user = await _context.User.ToListAsync();
                if (user == null || user.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (user, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(User?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null)
                    return (null, RepositoryStatus.NotExist);
                return (user, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(User? entity)
        {
            {
                try
                {
                    if (entity == null)
                        return RepositoryStatus.NullEntity;
                    _context.User.Update(entity);
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
}
