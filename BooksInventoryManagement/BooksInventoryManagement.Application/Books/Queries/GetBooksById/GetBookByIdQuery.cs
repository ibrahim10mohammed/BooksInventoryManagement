using BooksInventoryManagement.Application.Books.Queries.GetBooks;
using MediatR;

namespace BooksInventoryManagement.Application.Books.Queries.GetBooksById
{
    public class GetBookByIdQuery:IRequest<BookVm>
    {
        public int BookId { get; set; }
    }
}
