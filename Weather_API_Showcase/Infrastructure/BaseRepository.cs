using Infrastructure.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure
{
    public abstract class BaseRepository
    {
        private readonly DatabaseConfiguration _databaseConfiguration;
        private readonly AppDbContext _appDbContext;

        public BaseRepository(DatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        protected async Task<SqlConnection> GetConnectionAsync() 
        {
            SqlConnection connection = new SqlConnection(_databaseConfiguration.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
