using BooksInventoryManagement.Application.Books.Commands.BorrowBook;
using BooksInventoryManagement.Application.Books.Commands.CreateBook;
using BooksInventoryManagement.Application.Books.Commands.DeleteBook;
using BooksInventoryManagement.Application.Books.Commands.Return_Book;
using BooksInventoryManagement.Application.Books.Commands.UpdateBook;
using BooksInventoryManagement.Application.Books.Queries.GetBooks;
using BooksInventoryManagement.Application.Books.Queries.GetBooksById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksInventoryManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ApiControllerBase
    {
        [HttpGet("AllBooks")]
        public async Task<IActionResult> GetAllAsync([FromQuery] string keyword = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var books = await Mediator.Send(new GetBookQuery() { Keyword= keyword, PageNumber = pageNumber, PageSize = pageSize });
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if(id == 0)
            {
                return BadRequest("Enter Valid Id");
            }
            var book = await Mediator.Send(new GetBookByIdQuery() { BookId = id });
            if(book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand createBookCommand)
        {
            var book = await Mediator.Send(createBookCommand);
            if (book is null)
            {
                return BadRequest();
            }
            return Ok(book);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand updateBookCommand)
        {
            var isBookEdited = await Mediator.Send(updateBookCommand) > 0;
            if (!isBookEdited)
            {
                return BadRequest();
            }
            return Ok(isBookEdited);
        }
        [HttpPut("borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBookCommand borrowBookCommand)
        {
            var isBookBorrowed = await Mediator.Send(borrowBookCommand) > 0;
            if (!isBookBorrowed)
            {
                return NotFound("Book Not Found");
            }
            return Ok(isBookBorrowed);
        }
        [HttpPut("return")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookCommand returnBookCommand)
        {
            var isBookReturned = await Mediator.Send(returnBookCommand) > 0;
            if (!isBookReturned)
            {
                return NotFound("Book Not Found");
            }
            return Ok(isBookReturned);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var isBookEdited = await Mediator.Send(new DeleteBookCommand() { Id = id }) > 0;
            if (!isBookEdited)
            {
                return NotFound("Book Not Found");
            }
            return Ok(isBookEdited);
        }
    }
}
