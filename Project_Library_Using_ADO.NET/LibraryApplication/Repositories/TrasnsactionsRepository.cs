
﻿using Library_Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Library_Infrastructure.Constants;
using System.Data;
using System.Net;


namespace Library_Infrastructure.Repositories
{
    public class TrasnsactionsRepository : Base_Repository, ITransactionsRepository
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public TrasnsactionsRepository(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }



        public void CreateTransaction(int memberId, int bookId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spCreateTransaction, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }



        public bool DoesTransactionExist(int memberId, int bookId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesTransactionExist, connection);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    return ((int)cmd.ExecuteScalar() > 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }



        public void UpdateTransaction(int memberId, int bookId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spUpdateTransaction, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }



        public bool HasMemberAlreadyRentedBook(int memberId, int bookId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spHasMemberAlreadyRentedBook, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);

                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }

    }
}
