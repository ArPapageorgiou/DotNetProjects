using ADO_Student_Domain.Entities;
using ADO.Application.Interfaces;

namespace ADO.Application.Services
{
    public class Application : IApplication
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEnumerable<Student> _students = new List<Student>()
        {
                new Student(){Name = "A", Age=25, IsCool=true},
                new Student(){Name = "B", Age=25, IsCool=true},
                new Student(){Name = "C", Age=25, IsCool=true},
                new Student(){Name = "D", Age=25, IsCool=true},
                new Student(){Name = "E", Age=25, IsCool=true},
                new Student(){Name = "F", Age=25, IsCool=true},
                new Student(){Name = "G", Age=25, IsCool=true}
        };

        public Application(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }

        public void Run()
        {
            if (_students is null || !_students.Any())
            {
                throw new Exception("Students cannot be null or empty.");
            }
            _studentRepository.BulkInsertStudentsWithText(_students);
        }

        public void BulkInsertTextRun() 
        {
            if (_students is null || !_students.Any()) 
            {
                throw new Exception("Students cannot be null or empty");
            }
            _studentRepository.BulkInsertStudentsWithText(_students);
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
        }
    }
}
