using Library.Model;

namespace Library.Service
{
    public interface IBookService
    {
        Task<bool> AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<IEnumerable<Book>> GetAllBookAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> UpdateBookAsync(Book book);
    }
}
