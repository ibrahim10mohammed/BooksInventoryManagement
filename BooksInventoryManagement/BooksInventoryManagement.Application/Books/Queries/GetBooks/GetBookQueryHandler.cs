using AutoMapper;
using BooksInventoryManagement.Application.Common.ViewModels;
using BooksInventoryManagement.Domain.Repository;
using MediatR;

namespace BooksInventoryManagement.Application.Books.Queries.GetBooks
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, PaginatedResponse<BookVm>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookQueryHandler(IBookRepository bookRepository,IMapper mapper) 
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<BookVm>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _bookRepository.GetTotalCountAsync(request.Keyword, request.PageNumber, request.PageSize);

            var books = await _bookRepository.GetBooksAsync(request.Keyword,request.PageNumber, request.PageSize);

            var booksList = _mapper.Map<List<BookVm>>(books);
            return new PaginatedResponse<BookVm>
            {
                Items = booksList,
                TotalCount = totalCount
            };
        }
    }
}
