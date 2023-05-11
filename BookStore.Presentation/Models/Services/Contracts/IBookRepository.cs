using BookStore.Domain.Entities;

namespace BookStore.Presentation.Models.Services.Contracts
{
    public interface IBookRepository
    {
        List<Book>? SelectAll();
        Book? Select(int? id);
        void Insert(Book? book);
        void Update(Book? book);
        void Delete(int? id);
    }
}
