using BooksInventoryManagement.Domain.Repository;

namespace BooksInventoryManagement.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBookRepository _bookRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _bookRepository = new BookRepository(_dbContext);
        }

        public IBookRepository Books => _bookRepository;

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
