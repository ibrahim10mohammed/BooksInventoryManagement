
namespace BooksInventoryManagement.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; } 
        Task<int> CommitAsync();       
        void Rollback();
    }
}
