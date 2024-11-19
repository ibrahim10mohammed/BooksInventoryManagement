using MediatR;

namespace BooksInventoryManagement.Application.Books.Commands.BorrowBook
{
    public class BorrowBookCommand : IRequest<int>
    {
        public int BookId { get; set; }
    }
}
