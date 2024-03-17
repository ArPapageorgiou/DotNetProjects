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
    }
}
