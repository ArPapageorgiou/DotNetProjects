using Library_Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Library_Infrastructure.Constants;
using System.Data;



namespace Library_Infrastructure.Repositories
{

    public class BooksRepository : Base_Repository, IBooksRepository 
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public BooksRepository(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
                _databaseConfiguration = databaseConfiguration;
        }


        public bool DoesBookExistById(int bookId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesBookExistById, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
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





        public bool DoesBookExistByTitle(string title)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesBookExistByTitle, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", title);

                    return ((int)cmd.ExecuteScalar() > 0);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }




        public bool IsBookAvailable(int bookId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesBookExistById, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
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
        
        
        
        public bool IsBookAvailable(string title) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesBookExistByTitle, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", title);
                    return ((int)cmd.ExecuteScalar() > 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }
        
        
        
        public Books GetBook(int bookId) 
        {
            Books book = null;

            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                { 
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetBookById, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        reader.Read();
                        book = new Books
                        {
                            BookId = Convert.ToInt32(reader["BookId"]),
                            Title = reader["Title"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            Description = reader["Description"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            TotalCopies = Convert.ToInt32(reader["TotalCopies"]),
                            AvailableCopies = Convert.ToInt32(reader["AvailableCopies"]),
                            IsDeleted = Convert.ToBoolean(reader["AvailableCopies"])


                        };
                      
                            
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return book;

        }
        
        
        
        public Books GetBook(string title) 
        {
            Books book = null;

            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetBookByTitle, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", title);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        book = new Books
                        {
                            BookId = Convert.ToInt32(reader["BookId"]),
                            Title = reader["Title"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            Description = reader["Description"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            TotalCopies = Convert.ToInt32(reader["TotalCopies"]),
                            AvailableCopies = Convert.ToInt32(reader["AvailableCopies"]),
                            IsDeleted = Convert.ToBoolean(reader["AvailableCopies"])


                        };


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return book;
        }
        
        
        
        public IEnumerable<Books> GetAllBooks() 
        {
            List<Books> books = new List<Books>();
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetAllBooks, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows) 
                    { 
                    while (reader.Read()) 
                        {
                            Books book = new Books
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                Title = reader["Title"].ToString(),
                                Genre = reader["Genre"].ToString(),
                                Description = reader["Description"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                TotalCopies = Convert.ToInt32(reader["TotalCopies"]),
                                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"]),
                                IsDeleted = Convert.ToBoolean(reader["AvailableCopies"])
                            };

                            books.Add(book);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return books;
        }
        
        
        
        public IEnumerable<Books> GetAvailableBooks() 
        {
            List<Books> books = new List<Books>();
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetAvailableBooks, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Books book = new Books
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                Title = reader["Title"].ToString(),
                                Genre = reader["Genre"].ToString(),
                                Description = reader["Description"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                TotalCopies = Convert.ToInt32(reader["TotalCopies"]),
                                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"]),
                                IsDeleted = Convert.ToBoolean(reader["AvailableCopies"])
                            };

                            books.Add(book);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return books;
        }
        
        
        
        public IEnumerable<Books> GetAllRentedBooks() 
        {
            List<Books> books = new List<Books>();
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetAllRentedBooks, connection);
                    cmd.CommandType= CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows) 
                    {
                        while (reader.Read()) 
                        {
                            Books book = new Books
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                Title = reader["Title"].ToString(),
                                Genre = reader["Genre"].ToString(),
                                Description = reader["Description"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                TotalCopies = Convert.ToInt32(reader["TotalCopies"]),
                                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"]),
                                IsDeleted = Convert.ToBoolean(reader["AvailableCopies"])
                            };

                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return books;
        }
        
        
        
        public IEnumerable<Books> GetAllNotRentedBooks() 
        {
            List<Books> books = new List<Books>();
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetAllNotRentedBooks, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Books book = new Books
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                Title = reader["Title"].ToString(),
                                Genre = reader["Genre"].ToString(),
                                Description = reader["Description"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                TotalCopies = Convert.ToInt32(reader["TotalCopies"]),
                                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"]),
                                IsDeleted = Convert.ToBoolean(reader["AvailableCopies"])
                            };

                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return books;
        }
        
        
        
        public void InsertNewBook(Books book) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spInsertNewBook, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title",book.Title);
                    cmd.Parameters.AddWithValue("@Genre", book.Genre);
                    cmd.Parameters.AddWithValue("@Description", book.Description);
                    cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                    cmd.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
                    cmd.Parameters.AddWithValue("@AvailableCopies", book.AvailableCopies);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }
        
        
        
        public void AddRemoveBookCopy(int bookId, int ChangeByNumber) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spAddRemoveBookCopy, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@ChangeByValue", ChangeByNumber);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }



    }
}
