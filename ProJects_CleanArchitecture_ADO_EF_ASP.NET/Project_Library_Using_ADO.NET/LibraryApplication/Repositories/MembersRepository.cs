
using Library_Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Library_Infrastructure.Constants;
using System.Data;

namespace Library_Infrastructure.Repositories
{
    public class MembersRepository : Base_Repository, IMembersRepository
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public MembersRepository(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }


        public bool DoesMemberExistById(int memberId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesMemberExistById, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    
                    return ((int)cmd.ExecuteScalar() > 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }



        public bool DoesMemberExistByFullName(string fullName)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDoesMemberExistByFullName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberFullName", fullName);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }



        public bool MemberHasMaxBooks(int memberId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spMemberHasMaxBooks, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    return (int)cmd.ExecuteScalar() > 1;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                return false;
            }
        }
        
        
        
        public Members GetMember(int memberId) 
        {
            Members member = null;

            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetMemberById, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MemberId", memberId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        member = new Members
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Phone"].ToString(),
                            RentedBooksCount = Convert.ToInt32(reader["RentedBooksCount"]),
                            IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                        };


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return member;
        }
        
        
        
        public Members GetMember(string fullName) 
        {
            Members member = null;

            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spGetMemberByFullName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        member = new Members
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Phone"].ToString(),
                            RentedBooksCount = Convert.ToInt32(reader["RentedBooksCount"]),
                            IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                        };


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }

            return member;
        }
        
        
        
        public void InsertMember(Members members) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spInsertMember, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", members.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", members.LastName);
                    cmd.Parameters.AddWithValue("@Address", members.Address);
                    cmd.Parameters.AddWithValue("@Phone", members.Phone);
                    cmd.Parameters.AddWithValue("@Email", members.Email);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }
        
        
        
        public void AddRentedBookToMember(int memberId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spAddRentedBookToMember, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.ExecuteNonQuery(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }
        
        
        
        public void RemoveRentedBookFromMember(int memberId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spRemoveRentedBookFromMember, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }
        
        
        
        public void DeleteMember(int memberId) 
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedures.spDeleteMember, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
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
