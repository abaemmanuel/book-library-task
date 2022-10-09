using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.ViewModel;
using my_books.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksServices _bookServices;

        public BooksController(BooksServices booksServices)
        {
            _bookServices = booksServices;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookServices.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)//Nb:the "id" parameter must be thesame with the route id to enable the API endpoint map the URL parameter and the method parameter 
        {
            var allBook = _bookServices.GetBookById(id);
            return Ok(allBook);
        }

        [HttpGet("get-book-and-authors-by-id/{id}")]
        public IActionResult GetBookByIdAndAuthors(int id) 
        {
            var allBookWithAuthor = _bookServices.GetBookByIdWithAuthors(id);
            return Ok(allBookWithAuthor);
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookServices.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _bookServices.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _bookServices.DeleteBookById(id);
            return Ok(); 
        }

    }
}
