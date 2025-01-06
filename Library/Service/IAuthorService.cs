using Library.Model;

namespace Library.Service
{
    public interface IAuthorService
    {
        Task<bool> AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);
        Task<IEnumerable<Author>> GetAllAuthorAsync();
        Task<Author> GetAuthorByIdAsync(int id);
    }
}
