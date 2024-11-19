using AutoMapper;
using BooksInventoryManagement.Application.Books.Queries.GetBooks;
using BooksInventoryManagement.Domain.Entities;
using BooksInventoryManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Books.Commands.CreateBook
{
    public class CreateBookHandler :IRequestHandler<CreateBookCommand,BookVm>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookHandler(IBookRepository bookRepository,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookVm> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = new Book { Title = request.Title, AuthorName = request.AuthorName, PublicationDate = request.PublicationDate };
            var result = await _bookRepository.CreateBookAsync(bookEntity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<BookVm>(result);
        }
    }
}
