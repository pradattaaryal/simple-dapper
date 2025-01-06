using Dapper;
using Library.Databaseconfig;
using Library.Model;
using System.Data;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public BookRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Book>> GetAllbookAsync()
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "GetAll");

                return await connection.QueryAsync<Book>(
                    "usp_ManageBooks",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "GetById");
                parameters.Add("@Id", bookId);

                return await connection.QueryFirstOrDefaultAsync<Book>(
                    "usp_ManageBooks",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", book.Name);
                parameters.Add("@Description", book.Description);
                parameters.Add("@Title", book.Title);
                parameters.Add("@Flag", "Create");

                var count=await connection.ExecuteScalarAsync<int>(
                    "usp_ManageBooks",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return count > 0;
            }
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@Id", book.Id);
                parameters.Add("@Name", book.Name);
                parameters.Add("@Description", book.Description);
                parameters.Add("@Title", book.Title);
                parameters.Add("@Flag", "Update");

                var rowsAffected = await connection.ExecuteAsync(
                    "usp_ManageBooks",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", bookId);
                parameters.Add("@Flag", "Delete");

                var rowsAffected = await connection.ExecuteAsync(
                    "usp_ManageBooks",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
