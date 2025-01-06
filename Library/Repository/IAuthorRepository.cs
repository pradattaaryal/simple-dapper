using Library.Model;

namespace Library.Repository
{
    public interface IAuthorRepository
    {
        Task<bool> AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int authorId);
        Task<IEnumerable<Author>> GetAllAuthorAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
    }
}
