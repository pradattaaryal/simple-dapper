using Library.Model;
using Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //GET: api/Book
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookService.GetAllBookAsync();
        }
        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<Book> GetById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return book;  // If the book is null, a 404 is automatically returned by ASP.NET Core
        }
        // POST: api/Book/create
        [HttpPost("create")]
        public async Task<bool> Create(Book book)
        {
            return await _bookService.AddBookAsync(book);  // Will return true or false
        }

        // PUT: api/Book/update/5
        [HttpPut("update/{id}")]
        public async Task<bool> Update(int id, Book book)
        {

            return await _bookService.UpdateBookAsync(book);  // Will return true or false
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _bookService.DeleteBookAsync(id);  // Will return true or false
        }
    }
}

   
