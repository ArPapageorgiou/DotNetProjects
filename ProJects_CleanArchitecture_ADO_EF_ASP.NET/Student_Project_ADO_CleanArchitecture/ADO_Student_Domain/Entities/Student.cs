namespace ADO_Student_Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsCool { get; set; }
        public bool IsDeleted { get; set; }
    }
}
