using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Services
{
    public class AuthorRepository : IAuthorRepository<Guid?, bool?>
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Author? entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Author? entity)
        {

            entity.Id = new Guid();
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<bool?> IsExist(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Author?>> SelectAllAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author?> SelectByIdAsync(Guid? id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author;
        }

        public async Task UpdateAsync(Author? entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
