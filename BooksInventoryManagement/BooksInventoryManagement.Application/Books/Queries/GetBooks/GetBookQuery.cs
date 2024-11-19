using BooksInventoryManagement.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Books.Queries.GetBooks
{
    public class GetBookQuery : IRequest<PaginatedResponse<BookVm>>
    {
        public string Keyword { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    //public record GetBookQuery :IRequest <List<BookVm>>;
}
