using BooksInventoryManagement.Application.Books.Queries.GetBooks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand :IRequest<BookVm>
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
