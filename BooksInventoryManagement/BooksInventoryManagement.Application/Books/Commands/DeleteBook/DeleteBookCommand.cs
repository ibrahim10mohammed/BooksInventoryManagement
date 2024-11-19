using MediatR;

namespace BooksInventoryManagement.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
