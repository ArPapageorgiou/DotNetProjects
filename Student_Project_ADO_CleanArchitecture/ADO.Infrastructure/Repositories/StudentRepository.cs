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

        void BulkInsertStudentsWithProcedure(IEnumerable<Student> students) 
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


        public void BulkInsertStudentsWithText(IEnumerable<Student> students) 
        {
            try
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
            catch (Exception e) 
            {
                Console.WriteLine("Error: " + e.Message);
            }


        }

        public IEnumerable<Student> GetAllStudentsWithProcedure()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("spGetAllStudentsWithProcedure", connection);
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

                    SqlCommand command = new SqlCommand("spGetCoolStudents", connection);
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
                    SqlCommand command = new SqlCommand("spGetStudentWithId", connection);
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
            throw new NotImplementedException();
        }

        public void HardDeleteAStudentWithText(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertStudentWithProcedure(Student student)
        {
            throw new NotImplementedException();
        }

        public void InsertStudentWithText(Student student)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteAStudentWithProcedure(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteAStudentWithText(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentWithProcedure(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentWithText(Student student)
        {
            throw new NotImplementedException();
        }

    }
}
