using System.Diagnostics.CodeAnalysis;

namespace LINQ_Operators_Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            //OrderBy()/OrderByDescending() and ThenBy()/ThenByDescending Operator - Method Syntax
            //var results = employeeList.Join(departmentList, e => e.DepartmentId, d => d.Id,
            //    (emp, dept) => new {
            //    Id = emp.Id,
            //    FirstName = emp.FirstName,
            //    LastName = emp.LastName,
            //    AnnualSalary = emp.AnnualSalary,
            //    DepartmentId = dept.Id,
            //    DepartmentName = dept.LongName
            //    }).OrderBy(o => o.DepartmentId).ThenBy(o => o.AnnualSalary); 

            //foreach (var item in results) 
            //{
            //    Console.WriteLine($"ID: {item.Id, -5} First Name: {item.FirstName,-10} Last name: {item.LastName, -10} Annual Salary: {item.AnnualSalary, -10} \tDepartment Name: {item.DepartmentName}");
            //}

            ////OrderBy()/OrderByDescending() and ThenBy()/ThenByDescending Operator - LINQ Query Syntax

            //var results = from emp in employeeList
            //              join dept in departmentList
            //              on emp.DepartmentId equals dept.Id
            //              orderby emp.DepartmentId,
            //              emp.AnnualSalary descending
            //              select new
            //              {
            //                  Id = emp.Id,
            //                  FirstName = emp.FirstName,
            //                  LastName = emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary,
            //                  DepartmentId = dept.Id,
            //                  DepartmentName = dept.LongName
            //              };

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"ID: {item.Id,-5} First Name: {item.FirstName,-10} Last name: {item.LastName,-10} Annual Salary: {item.AnnualSalary,-10} \tDepartment Name: {item.DepartmentName}");
            //}

            //GroupBy() Operator - Method Syntax - NOTE GroupBy execution is defered!
            //var results = employeeList.GroupBy(e => e.DepartmentId);
            //Group By - Query Syntax 
            //var results = from emp in employeeList
            //              orderby emp.DepartmentId
            //              group emp by emp.DepartmentId;

            //foreach (var empGroup in results) 
            //{
            //    Console.WriteLine($"Department ID: {empGroup.Key}");

            //    foreach (Employee emp in empGroup) 
            //    { 
            //    Console.WriteLine($"First Name: {emp.FirstName,-10} Last name: {emp.LastName,-10} Annual Salary: {emp.AnnualSalary,-10}");
            //    }
            //}

            //ToLookUp Operator - NOTE ToLookUp execution is immediate!
            //var groupResult = employeeList.ToLookup(e => e.DepartmentId);

            //foreach (var empGroup in groupResult)
            //{
            //    Console.WriteLine($"Department ID: {empGroup.Key}");

            //    foreach (Employee emp in empGroup)
            //    {
            //        Console.WriteLine($"First Name: {emp.FirstName,-10} Last name: {emp.LastName,-10} Annual Salary: {emp.AnnualSalary,-10}");
            //    }
            //}


            //----------QUANTIFIERS----------

            //All Quantifier
            //var annualSalaryCompare = 50000;

            //bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAll)
            //{
            //    Console.WriteLine($"All employee Annual Salaries are above {annualSalaryCompare}");
            //}
            //else 
            //{ 
            // Console.WriteLine($"Not all employee Annual Salaries are above {annualSalaryCompare}");
            //}

            //Any Quantifier
            //bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAny)
            //{
            //    Console.WriteLine($"At least one employee Annual Salary is above {annualSalaryCompare}");
            //}
            //else 
            //{
            //    Console.WriteLine($"Not one employee Annual Salary is above {annualSalaryCompare}");
            //}


            //Contains Operator
            //Returns true if we pass in an object that is equal in value with an object in the relevant collection
            //For primitive types like int, string, or simple classes like Employee with standard equality semantics,
            //Contains works out of the box. However, if you want to customize how equality is determined for complex
            //types or want to use Contains with custom equality logic, you can either override Equals and GetHashCode
            //in your class or implement IEqualityComparer and provide your own comparison logic. This allows you to
            //define how equality is determined for instances of your class.
            //var searchEmployee = new Employee
            //{
            //    Id = 3,
            //    FirstName = "Douglas",
            //    LastName = "Roberts",
            //    AnnualSalary = 40000.2m,
            //    IsManager = false,
            //    DepartmentId = 2
            //};

            //bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());
            //if (containsEmployee)
            //{
            //    Console.WriteLine($"{searchEmployee.FirstName} {searchEmployee.LastName} with ID number {searchEmployee.Id} is contained within the collection");
            //}
            //else 
            //{
            //    Console.WriteLine($"No employee named {searchEmployee.FirstName} {searchEmployee.LastName} with ID number {searchEmployee.Id} was found within the collection");
            //}






        }




        
    }
    //Contains() by default will compare objects by reference.
    //For more complex comparisons you need to customise you comparison logic 
    //by implementing the IEqualityComparer in your class like this and then using your own
    //logic inside the two methods Equals() and GetHashCode{} like this:
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            if (x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }

    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 3
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);

            return departments;
        }

    }
}
