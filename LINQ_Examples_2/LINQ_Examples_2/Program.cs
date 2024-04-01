using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using static LINQ_Examples_2.EmployeeComparer;


namespace LINQ_Examples_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            //Equality Method
            //SequenceEqual checks if each item in each list matches in value and order
            //and returns a boolean

            //var integerList1 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
            //var integerList2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};

            //var boolSequenceEqual = integerList1.SequenceEqual(integerList2);
            //Console.WriteLine(boolSequenceEqual);
            //Comparing a primitive type like int in the above example is simple but
            //in order to make a comparison between more complex types like the Employee type
            //we need to tell the compiler how to establish equality between objects of the
            //Employee type. We can do this by implementing the built in IEqualityComparer
            //generic Interface and passing an instance of the class as a parameter toan   
            //over loaded version of the SequenceEqual method.
            //If we don't the following example returns false.

            //var employeeListCompare = Data.GetEmployees();
            //var boolSequenceEqual2 = employeeList.SequenceEqual(employeeListCompare, new EmployeeComparer());
            //Console.WriteLine(boolSequenceEqual2);

            //Concatination Method
            //Concat() method is used to concatenate two sequences or collections
            //into a single sequence

            //var integerList1 = new List<int> {1, 2, 3, 4};
            //var integerList2 = new List<int> {5, 6, 7, 8};

            //IEnumerable<int> intsListConcat = integerList1.Concat(integerList2);

            //foreach (var item in intsListConcat) 
            //{
            //    Console.WriteLine(item);   
            //}

            //Concat() but with a collection of complex type.
            //List<Employee> employeeList2 = new List<Employee> { new Employee {Id = 5, FirstName = "Tony", LastName = "Stark", AnnualSalary = 60000.0m}, new Employee {Id = 6, FirstName = "Debbie", LastName = "Townsend", AnnualSalary = 55000.0m}};

            //IEnumerable<Employee> results = employeeList.Concat(employeeList2);
            //foreach (var item in results) 
            //{
            //    Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");
            //}


            //Aggregate method: We can perform a custom operation on values within a collection
            //Aggregate() - Count() - Sum() - Max()
            //Employee and decimal inside the angle brackets <...> are type parameters. They represent
            //the element type of the relevant collection and the type of the accumulated result.
            //0 is the seed value parameter.
            //The lambda expression represents the aggregation function parameter. The parameters represent
            //the accumulator (totalAnnualSalary) and the current element in the sequence iteration (employee).
            decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal>(0, (totalAnnualSalary, e) =>
            {
                var bonus = (e.IsManager == true) ? 0.04m : 0.02m;

                totalAnnualSalary = e.AnnualSalary + (e.AnnualSalary * bonus) + totalAnnualSalary;

                return totalAnnualSalary;
            });

            Console.WriteLine($"Total Annual Salary of all employees including bonus is {totalAnnualSalary}$");

             


        }
    }

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
