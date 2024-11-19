using BooksInventoryManagement.Application.Books.Commands.BorrowBook;
using BooksInventoryManagement.Domain.Repository;
using MediatR;

namespace BooksInventoryManagement.Application.Books.Commands.Return_Book
{
    public class ReturnBookHandler : IRequestHandler<ReturnBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReturnBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.ReturnBookAsync(request.BookId);
            return await _unitOfWork.CommitAsync();
        }
    }
}
