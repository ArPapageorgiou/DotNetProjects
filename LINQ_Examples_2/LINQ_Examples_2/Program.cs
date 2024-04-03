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
            //generic Interface and passing an instance of the class as a parameter to an   
            //overloaded version of the SequenceEqual method.
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

            ////////Aggregate Operations - Aggregate() - Count() - Sum() - Max()
            //Aggregate method: We can perform a custom operation on values within a collection
            //Aggregate()

            //Employee and decimal inside the angle brackets <...> are type parameters. They represent

            //the element type of the relevant collection and the type of the expected accumulated result.

            //Inside the () we have the seed (0 in this case) which represents the initial value of the accumulator
            //and the lamda exression.
            //The lambda expression represents the aggregation function parameter.
            //The parameters inside the lamda exression represent the accumulator (totalAnnualSalary) and the current
            //element in the sequence iteration (employee).
            //decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal>(0, (totalAnnualSalary, e) =>
            //{
            //    var bonus = (e.IsManager == true) ? 0.04m : 0.02m;

            //    totalAnnualSalary = e.AnnualSalary + (e.AnnualSalary * bonus) + totalAnnualSalary;

            //    return totalAnnualSalary;
            //});

            //Console.WriteLine($"Total Annual Salary of all employees including bonus is {totalAnnualSalary}$");



            //say we want to output a comma delimeted string from our employee list collection.
            //Each delimeted item containing the employee full name, a dash and then the employee
            //annual salary.Each annual salary must include the appropriate bonus.
            //We also want to include a label preceding that string.

            //string data = employeeList.Aggregate<Employee, string>("Employee Annual Salary (including bonus): ", (s, employee) =>
            //{
            //    var bonus = (employee.IsManager == true) ? 0.04m : 0.02m;

            //    s += $"{employee.FirstName} {employee.LastName} - {employee.AnnualSalary + (employee.AnnualSalary * bonus)}, ";

            //    return s;
            //});

            //Console.WriteLine(data);


            //Now let's try the same thing but we have to remove the comma from the very end of our string result
            //We can exrpress this by passing a lamda exression as our 3rd argument to an overloaded version
            //of the Aggregate function. This argument allows to perform a final operation on the results of the
            //lamda exression passed in as the second argument.
            //First we need to declare the datatype of the third argument inside the <...> following the Aggregate method.
            //In the lamda expression passed in as our final argument we are using the Substring method to
            //remove 2 characters from the end of the result. That means a comma and a space will be removed.

            //string data = employeeList.Aggregate<Employee, string, string>("Employee Annual Salary (including bonus): ", (s, employee) =>
            //{
            //    var bonus = (employee.IsManager == true) ? 0.04m : 0.02m;

            //    s += $"{employee.FirstName} {employee.LastName} - {employee.AnnualSalary + (employee.AnnualSalary * bonus)}, ";

            //    return s;
            //}, s => s.Substring(0, s.Length - 2));

            //Console.WriteLine(data);


            //Average()
            //decimal average = employeeList.Average(e => e.AnnualSalary);

            //Console.WriteLine($"Average Employee Annual Salary: {average}");

            //Console.WriteLine();
            //But what if we want to find the average annual salary of employees in the technology department?
            //We can use method chaining and the where operator like this:
            //decimal averageTech = employeeList.Where(e => e.DepartmentId == 3).Average(e => e.AnnualSalary);

            //Console.WriteLine($"Average Annual Salary for Tech Department Employees: {averageTech}");

            //Console.WriteLine();

            //Count()
            //Count returns the number of records in a collection according to a condition, if any.
            //int CountEmployees = employeeList.Count(e => e.DepartmentId == 3);

            //Console.WriteLine($"Number of Employees: {CountEmployees}");

            //Sum 
            //Returns the sum total of values
            //decimal sumResult = employeeList.Sum(e => e.AnnualSalary);

            //Console.WriteLine($"Sum of Annual Salaries: {sumResult}");

            //Max 
            //returns the maximum value 
            //decimal maxResult = employeeList.Max(e => e.AnnualSalary);

            //Console.WriteLine($"Highest Annual Salary: {maxResult}");

            //Generation Methods
            //DefaultIfEmpty, Empty, Range, Range, Repeat

            //DefaultIfEmpty
            //The DefaultIfEmpty method is used to provide a default value if a sequence is empty.
            //we can check on the result by applying the ElementAt() method to return the first
            //element of our initially empty collection.
            //List<int> intList = new List<int>();
            //var newList = intList.DefaultIfEmpty();
            //Console.WriteLine(newList.ElementAt(0));
            //Now lets use it on the Employee datatype.
            //The dafault value for a reference type is null. But we can pass in a default value that we
            //would prefer to be returned in case the relevant collection is empty, like this:
            //List<Employee> employees = new List<Employee>();
            //var employees2 = employees.DefaultIfEmpty(new Employee { Id = 0 });
            //var result = employees2.ElementAt(0);

            //if (result.Id == 0)
            //{
            //    Console.WriteLine("The list is empty");
            //}

            //Empty method
            //This method is used to generate a new empty collection
            //Note that the Empty method is not an extension method of IEnumerable or IQueryable interfaces.
            //It instead is a static method included in the Enumerable static class.
            //Bellow we instantiate a new, empty sequence, strongly typed with Employee as the defined type
            //through the use of the empty method.
            //We can then chain the ToList() method to that operation and return an empty generic list.
            //IEnumerable<Employee> emptyEmployeeList = Enumerable.Empty<Employee>().ToList();

            //Range() 
            //We can use the Range method to return a collection of values that are within a specified range
            //We want to return a range of int values in a collection where the first item in a range has a
            //value of 25 and each subsequent item is incremented by a value of 1 until there are 20 values
            //in total inside the relevant collection.
            //The range method includes two parameters (start, count) where start is the first value in
            //the sequence and count is the the times the method is going to increment by, the step of the
            //incrementation is one.   
            //var intCollection = Enumerable.Range(25, 20);
            //foreach (var item in intCollection) 
            //{
            //    Console.WriteLine(item);
            //}


            //Repeat()
            //Let's say we want to generate a collection of a specified amount of elements where a value for
            //each element in the collection is repeated
            //Repeat(element, count)
            //var strCollection = Enumerable.Repeat("Placeholder", 10);
            //foreach (var item in strCollection) 
            //{
            //    Console.WriteLine(item);
            //}

            ///////Set Operations - Distinct, Except, Intersect, Union

            //Distinct()
            //Lets say we have a strongly typed generic List of integer values and that ome of which
            //are repeating values.
            //We want to perform a query against this list of int values where we only want distinct
            //values returned. To that end we can use the Distinct() method.
            //List<int> list = new List<int> {1,2,1,3,4,5,3,6,2,5,7,8,9,7};
            //var result = list.Distinct();
            //foreach (var item in result) 
            //{ 
            //    Console.WriteLine(item); 
            //}






            Console.WriteLine();
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
