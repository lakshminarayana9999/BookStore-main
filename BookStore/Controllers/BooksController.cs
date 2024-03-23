using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bkService)
        {
            _bookService = bkService;
        }

        [HttpGet("sorted-by-publisher")]
        public IActionResult GetBooksSortedByPublisher()
        {
            var sortedBooks = _bookService.GetBooksSortedByPublisher();
            return Ok(sortedBooks);
        }

        [HttpGet("sorted-by-author-first-name")]
        public IActionResult GetBooksSortedByAuthorFirstName()
        {
            var sortedBooks = _bookService.GetBooksSortedByAuthorFirstName();
            return Ok(sortedBooks);
        }


        [HttpGet("sorted-by-author-last-name")]
        public IActionResult GetBooksSortedByAuthorLastName()
        {
            var sortedBooks = _bookService.GetBooksSortedByAuthorLastName();
            return Ok(sortedBooks);
        }



        [HttpGet("sorted-by-title")]
        public IActionResult GetBooksSortedByTitle()
        {
            var sortedBooks = _bookService.GetBooksSortedByTitle();
            return Ok(sortedBooks);
        }

        [HttpGet("total-price")]
        public IActionResult GetTotalPriceOfBooks()
        {
            var totalPrice = _bookService.GetTotalPriceOfBooks();
            return Ok(totalPrice);
        }

        [HttpGet("chicago")]
        public IActionResult GetChicagoCitation([FromBody] Book book)
        {
            var chicago = _bookService.GetChicagoCitation(book);
            return Ok(chicago);
        }
        [HttpGet("MLA")]
        public IActionResult GetMLACitation([FromBody] Book book)
        {
            var mla = _bookService.GetMLACitation(book);
            return Ok(mla);
        }

        [HttpPut("update/{id}")]
        // [HttpPut("update/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book data is null");
            }

            var existingBook = _bookService.GetBookById(id);

            if (existingBook == null)
            {
                return NotFound($"Book with ID {id} not found");
            }

            existingBook.Title = book.Title;
            existingBook.AuthorFirstName = book.AuthorFirstName;
            existingBook.AuthorLastName = book.AuthorLastName;
            existingBook.Publisher = book.Publisher;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.Price = book.Price;

            _bookService.UpdateBook(existingBook);

            return Ok(existingBook);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound(); // Return 404 if the book with the specified id is not found
            }

            _bookService.DeleteBook(id);

            return NoContent(); // Return 204 indicating successful deletion
        }


        [HttpPost("create")]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book data is null");
            }

            _bookService.AddBook(book);

            return Ok(book);
        }

       
    }
}
