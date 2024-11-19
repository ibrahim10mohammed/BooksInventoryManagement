using BooksInventoryManagement.Application.Common.Mappings;
using BooksInventoryManagement.Domain.Entities;

namespace BooksInventoryManagement.Application.Books.Queries.GetBooks
{
    public class BookVm:IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
        public string BorrowedBy { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Quantity { get; set; }
    }
}
