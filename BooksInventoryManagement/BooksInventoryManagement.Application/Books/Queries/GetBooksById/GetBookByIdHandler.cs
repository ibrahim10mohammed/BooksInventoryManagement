using AutoMapper;
using BooksInventoryManagement.Application.Books.Queries.GetBooks;
using BooksInventoryManagement.Domain.Repository;
using MediatR;

namespace BooksInventoryManagement.Application.Books.Queries.GetBooksById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookVm>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookByIdHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookVm> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            return _mapper.Map<BookVm>(book);
        }
    }
}
