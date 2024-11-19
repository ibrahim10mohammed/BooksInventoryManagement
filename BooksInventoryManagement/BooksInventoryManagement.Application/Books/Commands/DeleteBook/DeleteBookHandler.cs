using BooksInventoryManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Books.Commands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteBookAsync(request.Id);
            return await _unitOfWork.CommitAsync();
        }
    }
}
