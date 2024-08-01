using System.Data.SqlClient;

namespace ADO.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        private readonly DataBaseConfiguration _dataBaseConfiguration;

        protected BaseRepository(DataBaseConfiguration dataBaseConfiguration)
        {
                _dataBaseConfiguration = dataBaseConfiguration;
        }

        protected SqlConnection GetSqlConnection() 
        {
            SqlConnection connection = new SqlConnection(_dataBaseConfiguration.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
