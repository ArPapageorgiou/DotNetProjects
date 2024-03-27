namespace TCPData
{

    public class Data

    {
        public static List<Employee> GetEmployees() 
        { 
        List<Employee> EmployeeList = new List<Employee>();
            Employee employee = new Employee
            { 
            Id = 1,
            FirstName = "Bob",
            LastName = "Jones",
            AnnualSalary = 60000.3m,
            IsManager = true,
            DepartmentId = 1,
            };
            Employee employee1 = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 2,
            };
            Employee employee2 = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 2,
            };
            Employee employee3 = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 1,
            };

            
            EmployeeList.Add(employee);
            EmployeeList.Add(employee1);
            EmployeeList.Add(employee2);
            EmployeeList.Add(employee3);
            


            return EmployeeList;
        }

        public static List<Department> GetDepartment() 
        { 
        List<Department> DepartmentList = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };

            Department department1 = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };

            Department department2 = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };


            DepartmentList.Add(department);
            DepartmentList.Add(department1);
            DepartmentList.Add(department2);
            


            return DepartmentList;

                

        }
    }
}
