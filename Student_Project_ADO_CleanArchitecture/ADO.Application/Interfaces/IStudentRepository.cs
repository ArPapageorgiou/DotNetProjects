using ADO_Student_Domain.Entities;

namespace ADO.Application.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudentWithProcedure(int id);
        Student GetStudentWithText(int id);
        IEnumerable<Student> GetAllStudentsWithProcedure();
        IEnumerable<Student> GetAllStudentsWithText();
        IEnumerable<Student> GetCoolStudentsWithProcedure();
        IEnumerable<Student> GetCoolStudentsWithText();
        void InsertStudentWithProcedure(Student student);
        void InsertStudentWithText(Student student);
        void UpdateStudentWithProcedure(Student student);
        void UpdateStudentWithText(Student student);
        void BulkInsertStudentsWithProcedure(IEnumerable<Student> students);
        void BulkInsertStudentsWithText(IEnumerable<Student> students);
        void HardDeleteAStudentWithProcedure(int id);
        void HardDeleteAStudentWithText(int id);
        void SoftDeleteAStudentWithProcedure(int id);
        void SoftDeleteAStudentWithText(int id);
    }
}
