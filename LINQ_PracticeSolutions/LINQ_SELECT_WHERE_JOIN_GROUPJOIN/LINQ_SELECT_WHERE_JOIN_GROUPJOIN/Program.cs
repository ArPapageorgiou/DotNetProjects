using System.Linq;
using System.Runtime.CompilerServices;

namespace LINQ_SELECT_WHERE_JOIN_GROUPJOIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SELECT and WHERE operators - Method Syntax
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            //var results = employeeList.Select(e => new
            //{
            //    FullName = e.FirstName + " " + e.LastName,
            //    AnnualSalary = e.AnnualSalary
            //}).Where(e=> e.AnnualSalary >= 50000);

            //foreach (var item in results) 
            //{ 
            //Console.WriteLine($"{item.FullName, -20} {item.AnnualSalary, 10}");
            //}



            //SELECT and WHERE operators - LINQ Querry Syntax
            //var results = from emp in employeeList 
            //              where emp.AnnualSalary >= 50000
            //              select new
            //              {
            //                  FullName = emp.FirstName
            //                  + " " + emp.LastName, 
            //                  AnnualSalary =emp.AnnualSalary
            //              };

            //Demonstrating the concept of defered execution where the query isnt excuted
            //until it is needed. This makes any update to the data source immediately
            //reflected to the results. Here execution is defered until the results are
            //traversed within the foreach loop.
            /*employeeList.Add(new Employee
            {
                Id = 5,
                FirstName = "Sam",
                LastName = "Davis",
                AnnualSalary = 50000,
                IsManager = true,
                DepartmentId = 2
            });

            foreach (var item in results) 
            { 
            Console.WriteLine($"{item.FullName, -20} {item.AnnualSalary, 10}");
            }*/


            //Note that defered execution reevaluates on each execution
            //which is known as lazy evaluation
            //var results = from emp in employeeList.GetHighSalariedEmployees()
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary
            //              };

            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "Sam",
            //    LastName = "Davis",
            //    AnnualSalary = 100000,
            //    IsManager = true,
            //    DepartmentId = 2
            //});

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");

            //    Console.WriteLine();

            //}


            //Immediate Query execution Example. In order to execute a query immediately
            //we need to use a .To conversion
            //var results = (from emp in employeeList.GetHighSalariedEmployees()
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary
            //              }).ToList();


            //using the .ToList conversion makes the program immediately convert the result to a list and store it in memory.
            //which is precisely the opposite of defered execution.


            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "Sam",
            //    LastName = "Davis",
            //    AnnualSalary = 100000,
            //    IsManager = true,
            //    DepartmentId = 2
            //});
            //our new employee "Sam Davis" is not included in the results so it's easy to conclude
            //our query executed immediately.


            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");

            //    Console.WriteLine();

            //}

            //JOIN operator - Method Syntax
            //var results = departmentList.Join(employeeList,
            //    department => department.Id,
            //    employee => employee.DepartmentId,
            //    (department, employee) => new 
            //    { 
            //    FullName = employee.FirstName + " " + employee.LastName,
            //    AnnualSalary = employee.AnnualSalary,
            //    DepartmentName = department.LongName
            //    }
            //    );

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");

            //}

            //JOIN operator - LINQ Query Syntax

            //var results = from employee in employeeList
            //              join department in departmentList
            //              on employee.DepartmentId equals department.Id
            //              select new
            //              {
            //                  FullName = employee.FirstName + " " + employee.LastName,
            //                  AnnualSalary = employee.AnnualSalary,
            //                  DepartmentName = department.LongName

            //              };

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");

            //}

            //GROUP JOIN - Method Syntax
            //var results = departmentList.GroupJoin(employeeList,
            //    dept => dept.Id,
            //    emp => emp.DepartmentId,
            //    (dept, employeeGroup) => new {
            //        Employees = employeeGroup,
            //        DepartmentName = dept.LongName
            //    }
            //    );

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"Department Name: {item.DepartmentName}");

            //    foreach (var emp in item.Employees)
            //        Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
            //}

            //GROUP JOIN - LINQ Query Syntax
            var results = from department in departmentList
                          join employee in employeeList
                          on department.Id equals employee.DepartmentId
                          into employeeGroup // we use into keyword to assign the employee collection to a variable
                          select new
                          {
                              Employees = employeeGroup,
                              DepartmentName = department.LongName

                          };

            foreach (var item in results)
            {

                Console.WriteLine($"Department Name: {item.DepartmentName}");

                foreach (var emp in item.Employees)
                    Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
            }
            //Group Join operation will not return results from the EmployeeList If there are no corresponding
            //employees for a department. This after all is nothing more than a left outer join operation.
            

            Console.WriteLine();

        }
    }

        public static class EnumerableCollectionExtensionMethods
        {
            public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
            {
                foreach (Employee emp in employees)
                {
                    Console.WriteLine($"Accessing employee: {emp.FirstName + " " + emp.LastName}");

                    if (emp.AnnualSalary >= 50000)

                        yield return emp; //yield return the programm doesnt generate all high salaried amployees and put them in a list. That takes memory.
                                          //Instead it produces each employee as needed during itteration. producing them one by one as needed consumes less memory

                }
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
                    DepartmentId = 2
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

                    DepartmentId = 2

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

