using BookStore.Domain.Context;
using BookStore.Domain.Entities;
using BookStore.Presentation.Models.Services.Contracts;

namespace BookStore.Presentation.Models.Services.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Insert(Book? book)
        {
            try
            {
                if (book == null)
                    return;
                _context.Books.Add(book);
                _context.SaveChanges();
            } 
            catch (Exception) { throw; }
        }

        public void Delete(int? id)
        {
            if (_context.Books == null)
            {
                return;
            }
            var book =_context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            _context.SaveChanges();

        }

        public Book? Select(int? id)
        {
            try
            {
                if (id == null || _context.Books == null)
                {
                    return null;
                }
                var book = _context.Books
                .FirstOrDefault(m => m.Id == id);
                if (book == null)
                {
                    return null;
                }
                return book;
            }
            catch (Exception) { throw; }
        }

        public List<Book>? SelectAll()
        {
            try
            {
                if (_context.Books != null)
                    return _context.Books.ToList();
            }
            catch (Exception) { throw; }
            return null;
        }

        public void Update(Book? book)
        {
            if (book == null)
            {
                return;
            }

            try
            {
                _context.Update(book);
                _context.SaveChanges();
            }
            catch (Exception) { }
        }

    }
}
