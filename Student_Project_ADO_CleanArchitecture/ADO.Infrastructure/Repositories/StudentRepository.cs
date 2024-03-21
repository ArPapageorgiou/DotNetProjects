using ADO.Application.Interfaces;
using ADO.Infrastructure.Constants;
using ADO_Student_Domain.Entities;
using System.Data.SqlClient;
using System.Data;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetCoolStudentsWithText()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentWithProcedure(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentWithText(int id)
        {
            throw new NotImplementedException();
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
