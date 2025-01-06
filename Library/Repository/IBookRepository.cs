using Library.Model;

namespace Library.Repository
{
    public interface IBookRepository
    {
        Task<bool> AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<IEnumerable<Book>> GetAllbookAsync();
        Task<Book> GetBookByIdAsync(int id);
       
        Task<bool> UpdateBookAsync(Book book);
    }
}
