using Library.Model;
using Library.Repository;

namespace Library.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Get all books
        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            return await _bookRepository.GetAllbookAsync();
        }

        // Get a book by ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        // Add a new book
        public async Task<bool> AddBookAsync(Book book)
        {
            return await _bookRepository.AddBookAsync(book);
        }

        // Update an existing book
        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await _bookRepository.UpdateBookAsync(book);
        }

        // Delete a book by ID
        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }

    }
}
