using Library.CQRS.CommandHandler.AuthorCommandHandler;
using Library.Model;
using Library.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMediator _mediator;

        public AuthorController(IAuthorService authorService, IMediator mediator)
        {
            _authorService = authorService;
            _mediator = mediator;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _authorService.GetAllAuthorAsync();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<Author> GetById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id); // Corrected variable usage
            return author; // Return the correct object
        }

        // POST: api/Author/create
        [HttpPost("create")]
        public async Task<IActionResult> Create(Author author)
        {
            var result = await _mediator.Send(new CreateAuthorCommand { author = author });

            if (result)
                return Ok("Author created successfully.");
            return BadRequest("Failed to create the author.");
        }

        // PUT: api/Author/update/5
        [HttpPut("update/{id}")]
        public async Task<bool> Update(int id, Author author)
        {
            return await _authorService.UpdateAuthorAsync(author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _authorService.DeleteAuthorAsync(id); // Correct the route comment
        }
    }
}
