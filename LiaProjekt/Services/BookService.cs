using LiaProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiaProjekt.Services
{
    public class BookService
    {
        private readonly MyDbContext context;

        public BookService(MyDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                throw new KeyNotFoundException($"Boken med id {id} hittades inte.");

            return book;
        }

        public async Task<Book> DeleteBookById(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                throw new KeyNotFoundException($"Boken med id {id} hittades inte.");

            context.Books.Remove(book);
            await context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> AddBook(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateBook(int id, Book updatedBook)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                throw new KeyNotFoundException($"Boken med id {id} hittades inte.");

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Published = updatedBook.Published;

            await context.SaveChangesAsync();

            return book;
        }
    }
}
