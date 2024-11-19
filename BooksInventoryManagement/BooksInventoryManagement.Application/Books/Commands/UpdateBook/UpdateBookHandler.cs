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

namespace BooksInventoryManagement.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBookHandler(IBookRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var updatedBookEntity = new Book
            {
                AuthorName = request.AuthorName,
                Title = request.Title,
                PublicationDate = request.PublicationDate,
                ModifiedDate = DateTime.Now,
                Quantity = request.Quantity
            };
            await _bookRepository.UpdateBookAsync(request.Id, updatedBookEntity);
            return await _unitOfWork.CommitAsync();
        }
    }
}
