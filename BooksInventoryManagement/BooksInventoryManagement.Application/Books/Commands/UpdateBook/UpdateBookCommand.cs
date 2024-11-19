using BooksInventoryManagement.Application.Books.Queries.GetBooks;
using MediatR;

namespace BooksInventoryManagement.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand :IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsBorrowed { get; set; }
        public int Quantity { get; set; }
    }
}
