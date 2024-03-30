using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;

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
            //
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

            //OfType() Method Syntax 
            ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

            //search for strings
            //var stringResult = from s in mixedCollection.OfType<string>()
            //                   select s;

            //search for integers
            //var intResult = from s in mixedCollection.OfType<int>()
            //                select s;

            //search for all objects of the Employee class
            //var employeeResults = from s in mixedCollection.OfType<Employee>()
            //                      select s;
            //This query takes every element s of the mixed collection
            //and iterates though them one by one after the condition has beeen applied
            //and stores them to the the employeeResults variable

            //foreach (var item in employeeResults) 
            //{ 
            //Console.WriteLine($"{item.Id, -5} {item.FirstName, -10} {item.LastName, -10}");
            //}

            //search for all objects of the Department class
            //var departmentResults = from s in mixedCollection.OfType<Department>()
            //                      select s;

            //foreach (var item in departmentResults)
            //{
            //    Console.WriteLine($"{item.Id,-5} {item.LongName,-10} {item.ShortName,-10}");
            //}


            //ElementAt() We can pass the ordinal position of an element of a collection to the ElementAt()
            //method in order to have that element returned to us.
            var emp = employeeList.ElementAt(2);
            Console.WriteLine($"{emp.DepartmentId,-5} {emp.FirstName,-10} {emp.LastName,-10}");

            //ElementAtOrDefault() We can use this method in order to avoid an out of range exception.
            //The ElementAtOrDefault() method simply returns the default value for the desired item's
            //datatype (null, 0, false etc) in the case that there is no element found at the ordinal
            //position passed to the method.
            var singleEmp = employeeList.ElementAtOrDefault(8);
            //and we can write code to check if the return value is null
            if (singleEmp != null)
            {
                Console.WriteLine($"{singleEmp.DepartmentId,-5} {singleEmp.FirstName,-10} {singleEmp.LastName,-10}");
            }
            else 
            { 
            Console.WriteLine("No record found!");
            }

            //First() method 
            //is invoked as a method on an enumerable collection or query result
            //to retrieve the first element of the sequence that meets a specified
            //condition. If no condition is specified then this method simply returns
            //the first element of the relevant collection 
            List<int> intList = new List<int> { 1, 3, 5, 6, 7, 9 };
            int result = intList.First(i => i % 2 == 0);
            Console.WriteLine(result);
            //In case no value in the collection satisfies the condition then an
            //invalid operation exception is thrown.
            //We use FirstOrDefault() method in the same way that we use
            //ElementAtOrDefault() method to avoid exceptions like this.
            List<int> intList2 = new List<int> { 1, 3, 5, 7, 9 };
            int result2 = intList2.FirstOrDefault(i => i % 2 == 0);
            if (result2 != 0) //0 is the default value for integers
            {
                Console.WriteLine(result2);
            } 
            else 
            {
                Console.WriteLine("No even numbers found in the collection");
            }

            //Last() and LastOrDefault() methods work in precisely the same way as the above
            //only for the last element that satisfies the condition if any.
            List<int> intList3 = new List<int> { 1, 3, 5, 6, 7, 9, 10};
            int result3 = intList3.Last(i => i % 2 == 0);
            Console.WriteLine(result3);

            List<int> intList4 = new List<int> { 1, 3, 5, 7, 9 };
            int result4 = intList4.FirstOrDefault(i => i % 2 == 0);
            if (result4 != 0) 
            {
                Console.WriteLine(result4);
            }
            else
            {
                Console.WriteLine("No even numbers found in the collection");
            }

            //Single() and SingleOrDefault()
            //Single() and SingleOrDefault() return the only or the single element of a collection
            //that satisfy a given condition.
            //We have the option of passing a condition into the single method through the use
            //of a method overload or we can leave the brackets empty and pass no condition
            //into the method.
            //If we choose not to pass a condition into the Single() method and there is more
            //than one or no elements in the collection an invalid operation exception will be
            //thrown.
            //If however there is only a single element in the collection then that elemnt will
            //be returned by the query.
            //if we do choose to pass in a condition and zero or more than one elements satisfy
            //the condition then an invalid operation exception will be thrown.
            //We can avoid those exceptions by the use of SingleOrDefault() like in the previous cases

            List<Employee> employee2 = new List<Employee>();

            Employee SingleEmployee = new Employee
            {
                Id = 5,
                FirstName = "Dan",
                LastName = "Daniels",
                AnnualSalary = 80000.3m,
                IsManager = true,
                DepartmentId = 1
            };

            Employee SingleEmployee2 = new Employee
            {
                Id = 6,
                FirstName = "David",
                LastName = "Troudo",
                AnnualSalary = 70000.3m,
                IsManager = false,
                DepartmentId = 1
            };

            employee2.Add(SingleEmployee);
            employee2.Add(SingleEmployee2);

            var empSingle = employee2.Single(i => i.Id == 5);
            Console.WriteLine($"{empSingle.DepartmentId,-5} {empSingle.FirstName,-10} {empSingle.LastName,-10}");

            //Just like in the case of the Single() method the SingleOrDefault() method throws 
            //an invalid operation exception if there is more than one element that satisfies
            //the provided condition. 
            var empSingle2 = employee2.SingleOrDefault(i => i.DepartmentId == 1);
            if (empSingle2 != null)
            {
                Console.WriteLine($"{empSingle.DepartmentId,-5} {empSingle.FirstName,-10} {empSingle.LastName,-10}");
            }
            else 
            { 
                Console.WriteLine("This employee does not exist within the collection");   
            }





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

        //Lets create an ArrayList that stores different types to use in our OfType() example
        public static ArrayList GetHeterogeneousDataCollection() 
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(100);
            arrayList.Add("Bob Jones");
            arrayList.Add(2000);
            arrayList.Add(3000);
            arrayList.Add("Bill Henderson");
            arrayList.Add(new Employee {Id = 6, FirstName = "Jenifer", LastName = "Dale", AnnualSalary = 90000, IsManager = true});
            arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false });
            arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing"});
            arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Reasearch and Development" });
            arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });

            return arrayList;
        }

    }
}
