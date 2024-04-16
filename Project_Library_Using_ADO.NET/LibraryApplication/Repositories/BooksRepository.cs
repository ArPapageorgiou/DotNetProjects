using Library_Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Library_Infrastructure.Constants;
using System.Data;
using System.Net;


namespace Library_Infrastructure.Repositories
{
    public class BooksRepository : Base_Repository, IBooksRepository 
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public BooksRepository(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
                _databaseConfiguration = databaseConfiguration;
        }


        public bool DoesBookExist(int bookId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesBookExistById, connection);
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
        public bool DoesBookExist(string title) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesBookExistByTitle, connection);//a select count query where if query result is 1 then return true
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", title);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }
        public bool IsBookAvailable(int bookId) { }
        public bool IsBookAvailable(string title) { }
        public Books GetBook(int id) { }
        public Books GetBook(string title) { }
        public IEnumerable<Books> GetAllBooks() { }
        public IEnumerable<Books> GetAvailableBooks() { }
        public IEnumerable<Books> GetAllRentedBooks() { }
        public IEnumerable<Books> GetAllNotRentedBooks() { }
        public void InsertNewBook(Books book) { }
        public void AddRemoveBookCopy(int bookId, int ChangeByNumber) { }


    }
}
