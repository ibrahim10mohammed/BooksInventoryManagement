using MediatR;

namespace BooksInventoryManagement.Application.Books.Commands.Return_Book
{
    public class ReturnBookCommand: IRequest<int>
    {
        public int BookId { get; set; }
    }
}
