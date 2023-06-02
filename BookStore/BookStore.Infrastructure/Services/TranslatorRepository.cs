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
    public class TranslatorRepository : ITranslatorRepository<Guid?, bool, RepositoryStatus>
    {
        private readonly ApplicationDbContext _context;

        public TranslatorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryStatus> DeleteAsync(Translator? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                entity.IsDeleted = true;
                _context.Translator.Update(entity);
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
                var translator = await _context.Translator.FirstOrDefaultAsync(translator => translator.Id == id);
                if (translator == null) return RepositoryStatus.NullEntity;
                translator.IsDeleted = true;
                _context.Translator.Update(translator);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(Translator? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.Translator.AddAsync(entity);
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
                bool isExist = (_context.Translator?.Any(translator => translator.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<Translator?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var translators = await _context.Translator.ToListAsync();
                if (translators == null || translators.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (translators, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(Translator?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var translator = await _context.Translator.FirstOrDefaultAsync(translator => translator.Id == id);
                if (translator == null)
                    return (null, RepositoryStatus.NotExist);
                return (translator, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(Translator? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                _context.Translator.Update(entity);
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
