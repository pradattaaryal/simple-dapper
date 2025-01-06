using System.Data;
using Microsoft.Data.SqlClient; // Use Microsoft.Data.SqlClient for modern .NET
using Microsoft.Extensions.Configuration;

namespace Library.Databaseconfig
{
    public class DatabaseConfig
    {
        // Dapper
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DatabaseConfig(IConfiguration configuration) // Constructor name matches class name
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
