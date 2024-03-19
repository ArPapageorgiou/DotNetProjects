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

        public void BulkInsertStudentsWithProcedure(IEnumerable<Student> students) 
        { 
            SqlConnection connection = GetSqlConnection();
            SqlCommand command = new SqlCommand(StoredProcedures.spBulkInsertStudentsWithProcedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            DataTable studentTable = new DataTable();

            studentTable.Columns.Add("Name", typeof(string));
            studentTable.Columns.Add("Age", typeof(int));
            studentTable.Columns.Add("IsCool", typeof(bool));

            foreach (Student student in students)
            {
                studentTable.Rows.Add(student.Name, student.Age, student.IsCool);
            }

            SqlParameter parameter = command.Parameters.AddWithValue("@studentData", studentTable);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "dbo.udt_Student";

            command.ExecuteNonQuery();
            connection.Close();


        }

        public void BulkInsertStudentsWithText(IEnumerable<Student> students) 
        { 
        
        }

        public IEnumerable<Student> GetAllStudentsWithProcedure()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudentsWithText()
        {
            throw new NotImplementedException();
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
