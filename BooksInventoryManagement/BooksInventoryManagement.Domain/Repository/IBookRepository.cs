using BooksInventoryManagement.Domain.Entities;

namespace BooksInventoryManagement.Domain.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync(string keyWord, int pageNumber, int pageSize);
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<int> UpdateBookAsync(int id, Book book);
        Task<int> DeleteBookAsync(int id);
        Task<int> GetTotalCountAsync(string keyWord, int pageNumber, int pageSize);
        Task<bool> BorrowBookAsync(int id, Guid borrowedBy);
        Task<bool> ReturnBookAsync(int id);
    }
}
