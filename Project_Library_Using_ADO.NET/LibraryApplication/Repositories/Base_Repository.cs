
﻿using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace Library_Infrastructure.Repositories
{
    public abstract class Base_Repository
    {
    private readonly DatabaseConfiguration _dataBaseConfiguration;

     protected Base_Repository(DatabaseConfiguration databaseConfiguration)
        {
            _dataBaseConfiguration = databaseConfiguration;
        }

        protected SqlConnection GetSqlConnection() 
        {
            SqlConnection connection = new SqlConnection(_dataBaseConfiguration.ConnectionString);
            connection.Open();
            return connection;
        }
    }


}
