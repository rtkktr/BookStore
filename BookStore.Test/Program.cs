// See https://aka.ms/new-console-template for more information
using BookStore.Infrastructure.Services;

BookRepository bookRepository = new BookRepository(new BookStore.Infrastructure.ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<BookStore.Infrastructure.ApplicationDbContext>()));

await bookRepository.InsertAsync(new BookStore.Domain.Models.Book
{
    Id = 1,
    LongDescription = "abcdefg",
    PageNumber = 10,
    ProductCode = 1,
    PublishYear = 1400,
    Title = "Title",
    ShortDescription = "abc",
    UnitPrice = 10,
    Weight = 10,
});