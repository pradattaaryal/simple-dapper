using Library.Model;
using Library.Repository;

namespace Library.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // Get all authors
        public async Task<IEnumerable<Author>> GetAllAuthorAsync()
        {
            return await _authorRepository.GetAllAuthorAsync();
        }

        // Get an author by ID
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetAuthorByIdAsync(id);
        }

        // Add a new author
        public async Task<bool> AddAuthorAsync(Author author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }

        // Update an existing author
        public async Task<bool> UpdateAuthorAsync(Author author)
        {
            return await _authorRepository.UpdateAuthorAsync(author);
        }

        // Delete an author by ID
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            return await _authorRepository.DeleteAuthorAsync(id);
        }   
    }
}
