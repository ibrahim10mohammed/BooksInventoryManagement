using AutoMapper;
using BooksInventoryManagement.Application.Books.Commands.DeleteBook;
using BooksInventoryManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Books.Commands.BorrowBook
{
    public class BorrowBookHandler : IRequestHandler<BorrowBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BorrowBookHandler(IBookRepository bookRepository,IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.BorrowBookAsync(request.BookId, new Guid());
            return await _unitOfWork.CommitAsync();
        }
    }
}
