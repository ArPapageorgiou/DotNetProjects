using ADO.Application.Interfaces;
using ADO.Infrastructure.Constants;
using ADO_Student_Domain.Entities;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Server;

namespace ADO.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(DataBaseConfiguration dataBaseConfiguration) : base(dataBaseConfiguration)
        {
        }

        public void BulkInsertStudentsWithProcedure(IEnumerable<Student> students) 
        {
            using (SqlConnection connection = GetSqlConnection()) 
            {
                SqlCommand command = new SqlCommand(StoredProcedures.spBulkInsertStudentsWithProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;


                DataTable studentTable = new DataTable();
                studentTable.Columns.Add("Name", typeof(string));
                studentTable.Columns.Add("Age", typeof(int));
                studentTable.Columns.Add("IsCool", typeof(bool));

                foreach (var student in students) 
                { 
                studentTable.Rows.Add(student.Name, student.Age, student.IsCool);
                }

                var parameter = command.Parameters.AddWithValue("@StudentData", studentTable);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.udt_Student";

                command.ExecuteNonQuery();

            }

        }

        public void BulkInsertStudentsWithText(IEnumerable<Student> students) 
        {
             DataTable studentTable = new DataTable();
                
            studentTable.Columns.Add("Name", typeof(string));
                
            studentTable.Columns.Add("Age", typeof(int));
                
            studentTable.Columns.Add("IsCool", typeof(bool));

                
            foreach (var student in students) 
            {
                studentTable.Rows.Add(student.Name, student.Age, student.IsCool);
            }


            using (SqlConnection connection = GetSqlConnection()) 
            {
                using SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
                bulkCopy.DestinationTableName = Tables.Student;
                bulkCopy.ColumnMappings.Add("Name", "Name");
                bulkCopy.ColumnMappings.Add("Age", "Age");
                bulkCopy.ColumnMappings.Add("IsCool", "IsCool");

                bulkCopy.WriteToServer(studentTable);

            }

            Console.WriteLine("Bulk Insert Completed");


        }

        public IEnumerable<Student> GetAllStudentsWithProcedure()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand(StoredProcedures.spGetAllStudentsWithProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        Student student = new Student
                        {
                            Name = row["Name"].ToString(),
                            Age = Convert.ToInt32(row["Age"]),
                            IsCool = Convert.ToBoolean(row["IsCool"])
                        };

                        students.Add(student);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return students;
        }

        public IEnumerable<Student> GetAllStudentsWithText()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Student", connection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    dataAdapter.Fill(table);

                    foreach (DataRow row in table.Rows) 
                    {
                        Student student = new Student
                        {
                            Name = row["Name"].ToString(),
                            Age = Convert.ToInt32(row["Age"]),
                            IsCool = Convert.ToBoolean(row["IsCool"])
                        };

                        students.Add(student);
                    }

                    Console.WriteLine("Values retrieved for all students");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            
            return students;
        }

        public IEnumerable<Student> GetCoolStudentsWithProcedure()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {

                    SqlCommand command = new SqlCommand(StoredProcedures.spGetCoolStudents, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        Student student = new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            IsCool = Convert.ToBoolean(reader["IsCool"]),
                            IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                        };

                        students.Add(student);  
                    }

                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }

            return students;
        }

        public IEnumerable<Student> GetCoolStudentsWithText()
        {
            List<Student> students = new List<Student>();

            try
            {

                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand($"SELECT * FROM {Tables.Student} WHERE IsCool = 1", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        Student student = new Student()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            IsCool = Convert.ToBoolean(reader["IsCool"]),
                            IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                        };

                        students.Add(student);  
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }

            return students;
        }

        public Student GetStudentWithProcedure(int id)
        {
            Student student = null;

            try
            {

                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand(StoredProcedures.spGetStudentWithId, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader =command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        reader.Read();
                        student = new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            IsCool = Convert.ToBoolean(reader["IsCool"]),
                            IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                        };
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }

            return student;
        }

        public Student GetStudentWithText(int id)
        {
            Student student = null;

            try
            {

                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand($"SELECT * FROM {Tables.Student} Where Id = @Id", connection);
                    command.Parameters.AddWithValue ("Id", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        reader.Read();
                        student = new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            IsCool = Convert.ToBoolean(reader["IsCool"]),
                            IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                        };
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return student;
        }

        public void HardDeleteAStudentWithProcedure(int id)
        {
                try
                {
                    using (SqlConnection connection = GetSqlConnection()) 
                    {
                    SqlCommand command = new SqlCommand(StoredProcedures.spHardDeleteAStudent, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentId", id);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Student record with Id number {id} has been deleted.");
                    }
                }
                catch (Exception e)
                {
                Console.WriteLine("Error: " + e.Message);
                }
        }

        public void HardDeleteAStudentWithText(int id)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand("DELETE FROM dbo.Student WHERE Id = @StudentId", connection);
                    command.Parameters.AddWithValue("@StudentId", id);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Student record with Id number {id} has been deleted.");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void InsertStudentWithProcedure(Student student)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand(StoredProcedures.spInsertStudent, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@IsCool", student.IsCool);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Inserted new student record");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            
        }

        public void InsertStudentWithText(Student student)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand("INSERT INTO dbo.Student (Name, Age, IsCool) VALUES (@Name, @Age, @IsCool)", connection);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("IsCool", student.IsCool);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Inserted new student record");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void SoftDeleteAStudentWithProcedure(int id)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    SqlCommand command = new SqlCommand(StoredProcedures.spSoftDeleteStudent, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Student record with Id number {id} marked for deletion");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void SoftDeleteAStudentWithText(int id)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand("UPDATE dbo.Student SET IsDeleted = 1 WHERE Id = @Id");
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Student record with Id number {id} marked for deletion");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void UpdateStudentWithProcedure(Student student)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand(StoredProcedures.spUpdateStudent, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@IsCool", student.IsCool);
                    command.Parameters.AddWithValue("IsDeleted", student.IsDeleted);
                    
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Student record with Id number {student.Id} has been updated");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void UpdateStudentWithText(Student student)
        {
            try
            {
                using (SqlConnection connection = GetSqlConnection()) 
                {
                    SqlCommand command = new SqlCommand("UPDATE dbo.Student SET Name = @Name, Age = @Age, IsCool = @IsCool, IsDeleted = @IsDeleted WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@IsCool", student.IsCool);
                    command.Parameters.AddWithValue("IsDeleted", student.IsDeleted);

                    command.ExecuteNonQuery();

                    Console.WriteLine($"Student record with Id number {student.Id} has been updated");
                }
            }
            catch ( Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

    }
}
