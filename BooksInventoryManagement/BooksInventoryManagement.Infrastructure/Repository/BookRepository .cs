using BooksInventoryManagement.Domain.Entities;
using BooksInventoryManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace BooksInventoryManagement.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> BorrowBookAsync(int id, Guid borrowedBy)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null) return false;
            book.MarkAsBorrowed(borrowedBy);
            return true;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            return book;
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null) return 0;

            _dbContext.Books.Remove(book);
            return 1;
        }

        public async Task<List<Book>> GetBooksAsync(string keyword, int pageNumber, int pageSize)
        {
            var books = _dbContext.Books.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
                books = books.Where(b => b.Title.Contains(keyword) || b.AuthorName.Contains(keyword));
            return await books.Where(b => string.IsNullOrEmpty(keyword) || (b.Title.ToLower().Contains(keyword.ToLower()) || b.AuthorName.ToLower().Contains(keyword.ToLower()))).OrderBy(b => b.CreationDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<int> GetTotalCountAsync(string keyword, int pageNumber, int pageSize)
        {
            var books = _dbContext.Books.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
                books = books.Where(b => b.Title.Contains(keyword) || b.AuthorName.Contains(keyword));
            return await books.CountAsync();
        }

        public async Task<bool> ReturnBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null) return false;
            book.MarkAsReturned();
            return true;
        }

        public async Task<int> UpdateBookAsync(int id, Book book)
        {
            var existingBook = await _dbContext.Books.FindAsync(id);
            if (existingBook == null) return 0;

            existingBook.Title = book.Title;
            existingBook.AuthorName = book.AuthorName;
            existingBook.PublicationDate = book.PublicationDate;
            existingBook.Quantity = book.Quantity;
            existingBook.ModifiedDate = DateTime.Now;
            return 1;
        }
    }
}
