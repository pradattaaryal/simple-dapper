using Dapper;
using Library.Databaseconfig;
using Library.Model;
using System.Data;

namespace Library.Repository
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public AuthorRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorAsync()
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "GetAll");

                return await connection.QueryAsync<Author>(
                    "usp_ManageAuthors",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", "GetById");
                parameters.Add("@AuthorId", authorId);

                return await connection.QueryFirstOrDefaultAsync<Author>(
                    "usp_ManageAuthors",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> AddAuthorAsync(Author author)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", author.Name);
                parameters.Add("@Bio", author.Bio);
                parameters.Add("@Flag", "Create");

                var count = await connection.ExecuteScalarAsync<int>(
                    "usp_ManageAuthors",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return count > 0;
            }
        }

        public async Task<bool> UpdateAuthorAsync(Author author)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@AuthorId", author.AuthorId);
                parameters.Add("@Name", author.Name);
                parameters.Add("@Bio", author.Bio);
                parameters.Add("@Flag", "Update");

                var rowsAffected = await connection.ExecuteAsync(
                    "usp_ManageAuthors",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAuthorAsync(int authorId)
        {
            using (var connection = _databaseConfig.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AuthorId", authorId);
                parameters.Add("@Flag", "Delete");

                var rowsAffected = await connection.ExecuteAsync(
                    "usp_ManageAuthors",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
