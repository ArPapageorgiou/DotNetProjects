
﻿using Entity_Framework_Core__Basics.Models;
using Entity_Framework_Core__Basics.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.NetworkInformation;

namespace Entity_Framework_Core__Basics
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            //HOW TO ADD DATA TO DATABASE

            //1)Create instances of your model classes 

            //2)Add them to the appropriate DBSet property in your DBContext class

            //Call the SaveChanges method


            //to add data to the database we need to create an instance of AppDBContext so  that we can access it's
            //properties. We do this with a using statement to make sure that the instance is properly disposed of 
            //afterwards.

            //try 
            //{ 
            //using (var context = new AppDBContext())
            //{
            //        try 
            //        { 
            //        using (var transaction = context.Database.BeginTransaction())
            //        {
            //                //Insert manager details
            //                var manager = new Manager();
            //                manager.MngFirstName = "Ravi";
            //                manager.MngLastName = "G";
            //                //add data to the DbSet
            //                //context.Managers.Add(manager);

            //                var manager2 = new Manager();
            //                manager2.MngFirstName = "Sam";
            //                manager2.MngLastName = "K";
            //                //context.Managers.Add(manager2);

            //                var employee = new Employee();
            //                employee.FirstName = "Argiris";
            //                employee.LastName = "Papageorgiou";
            //                employee.EmpSalary = 100000;
            //                employee.ManagerId = 1;
            //                //context.Employees.Add(employee);

            //                var employee2 = new Employee();
            //                employee2.FirstName = "Giorgos";
            //                employee2.LastName = "Papageorgiou";
            //                employee2.EmpSalary = 120000;
            //                employee2.ManagerId = 1;
            //                //context.Employees.Add(employee2);

            //                var project = new Project();
            //                project.Name = "Development";
            //                //context.Project.Add(project);

            //                var employeeProject = new EmployeeProject();
            //                employeeProject.ProjectId = 1;
            //                employeeProject.EmployeeId = 2;
            //                //context.EmployeeProjects.Add(employeeProject);

            //                var employeeDetails = new EmployeeDetails();
            //                employeeDetails.Address = "Sarakou";
            //                employeeDetails.PhoneNumber = "12345098798";
            //                employeeDetails.Email = "papagiorgio@ado.net";
            //                employeeDetails.EmployeeId = 1;
            //                context.EmployeeDetails.Add(employeeDetails);

            //                var employeeDetails2 = new EmployeeDetails();
            //                employeeDetails2.Address = "Gripari";
            //                employeeDetails2.PhoneNumber = "4563798798";
            //                employeeDetails2.Email = "giorgio90@ado.net";
            //                employeeDetails2.EmployeeId = 2;
            //                context.EmployeeDetails.Add(employeeDetails2);


            //                //The SaveChanges method passes data to the database
            //                context.SaveChanges();
            //                //If all operations succeed then commit the transaction
            //                transaction.Commit();
            //        }
            //        }
            //        catch (Exception ex) 
            //        {
            //            Console.WriteLine(ex.Message);
            //        }



            //}
            //}
            //catch (Exception ex) 
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}

            /////////Retrieve, Update and Delete data in ef core using LINQ

            //Let's try to retrieve data from the database
            //try
            //{
            //    using (var context = new AppDBContext()) 
            //    { 
            //    var employees = context.Employees.ToList();

            //        foreach (var employee in employees) 
            //        {
            //            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.EmployeeId}");
            //        }
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("Error: " + e);
            //}

            //RETRIEVE
            //Now let's try to retrieve a specific set of data from the database
            //try
            //{
            //    using (var context = new AppDBContext()) 
            //    {
            //        var employee = context.Employees.Single(e => e.EmployeeId == 1);
            //        Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.EmployeeId}");
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("Error: " + e); ;
            //}

            //UPDATE
            //!. Retrieve the entity
            //2. Update the necessary properties of retrieved entity
            //3. Save the changes by calling SaveChanges() method

            //try
            //{
            //    using (var context = new AppDBContext()) 
            //    {
            //        var employee = context.Employees.Single(e => e.EmployeeId == 2);
            //        employee.EmpSalary = 110000;
            //        context.SaveChanges(); //until we call SaveChanges() method nothing will be updated in the datbase

            //        //Retrieve employee just to verify
            //        Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.EmployeeId} {employee.EmpSalary}");
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("Error: " + e); 
            //}

            //DELETE
            //!. Retrieve the entity
            //2. Delete the entity using the Remove() method
            //3. Save the changes by calling SaveChanges() method

            //try
            //{
            //    using (var context = new AppDBContext()) 
            //    {
            //        var employee = context.Employees.Single(e => e.EmployeeId == 1);
            //        if (employee != null)
            //        {
            //            context.Employees.Remove(employee);
            //            context.SaveChanges();
            //            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.EmployeeId} {employee.EmpSalary}");
            //        }
            //        else 
            //        { 
            //            Console.WriteLine($"Record no longer exists in Database");
            //        }
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("Error: " + e);
            //}

            /////EAGER LOADING
            ///retrieve related data along with the main data in a single database query, rather than making 
            ///additional queries for each related entity.
            ///When you eagerly load data, you're essentially telling the database to fetch not only the main 
            ///entity you requested but also its related entities in the same query.
            //Eager loading can be implemented in EF Core using the Include() method or the ThenInclude() method
            //Include and ThenInclude specify which related entities you want to eagerly load. 

            //using (var context = new AppDBContext()) 
            //{ 
            //var employees = context.Employees.Include(e => e.EmployeeDetails).ToList();
            //    foreach (var employee in employees) 
            //    {
            //        Console.WriteLine($"Id: {employee.EmployeeDetails.EmployeeId} {employee.FirstName} {employee.LastName} {employee.EmployeeDetails.Address}");
            //    }
            //}

            //Eager loading Many-To-Many relationship
            //The Include method allows you to specify which navigation properties to load and the ThenInclude
            //method enables you to include further related entities
            //using (var context = new AppDBContext()) 
            //{
            //    Console.WriteLine("Eager loading Many-To-Many relationship");

            //    var projects = context.Project.Include(p => p.EmployeeProjects)
            //        .ThenInclude(p => p.Employee).ToList();

            //    foreach (var project in projects) 
            //    {
            //        Console.WriteLine($"Project Name: {project.Name}");
            //        foreach (var employee in project.EmployeeProjects) 
            //        {
            //            Console.WriteLine($"Employee: {employee.Employee.FirstName}");
            //        }
            //    }

            //}

            //Advanteges:
            //Eager loading reduces the number of round-trips required to retrieve data and thus improves performance.
            //Minimizes network traffic as instead of sending multiple request to the database for retrieving related entities
            //you can fetch them all in a single query.

            //Disadvantages
            //Increased Data transfer size
            //Overfetching of data. It can result in unnecessary data being fetched, wasting resources and
            //impacting performance


            //////EXPLICIT LOADING
            //Explicit Loading is a technique in which related data is explicitly loaded from the database
            //at a later time.That means related data is not loaded at the same time with main data.
            //Entry() - Collection() - Reference()
            //To implement Explicit loading we can use the Entry method of the DbContext class along with the
            //Collection or Reference Methods to explicitly load related entities.

            //using (var context = new AppDBContext()) 
            //{ 
            //    //Loading Main Entity
            //var employees = context.Employees.ToList();

            //    foreach (var employee in employees) 
            //    {
            //        //Loading Related Entity
            //        context.Entry(employee).Reference(e => e.EmployeeDetails).Load();
            //        //Entry() retrieves an EntityEntry object for the given entity. An EntityEntry object represents
            //        //an entity being tracked by the context. EntityEntry provides various methods and properties to interact with
            //        //the entity being tracked.

            //        //Reference() is called on an EntityEntry object obtained through the Entry method.
            //        //It specifies a reference navigation property of the entity for which you want to load related data.
            //        //Reference navigation properties represent associations where there's a single related entity (as opposed
            //        //to collection navigation properties, which represent associations with multiple related entities).

            //        //Load() is called after specifying a reference navigation property using the Reference method. It executes
            //        //a database query to load the related entity data into memory.
            //        Console.WriteLine($"Id: {employee.EmployeeDetails.EmployeeId} Name: {employee.FirstName} Address: {employee.EmployeeDetails.Address}");
            //    }

            //}

            //Explicit Loading one-To-Many relationships
            //using (var context = new AppDBContext()) 
            //{ 
            //var managers = context.Managers.ToList();
            //    foreach (var manager in managers) 
            //    {
            //        Console.WriteLine($"Full Name: {manager.MngFirstName} {manager.MngLastName}");
            //        context.Entry(manager).Collection(m => m.Employees).Load();
            //        //Collection method is being used instead of Reference method, this is appropriate
            //        //when dealing with a one-to-many or many-to-many relationship where there's a
            //        //collection of related entities.

            //

            //        foreach (var employee in manager.Employees) 
            //        {
            //            Console.WriteLine($"Full Name: {employee.FirstName} {employee.LastName}");
            //        }
            //    }
            //}

            ////Advantages of Explicit Loading:
            //Improved performance as it allows you to load related entities on demand, reducing the amount of data
            //retrieved from the databasse
            //Reduced memory usage. By selectively loading related entities when needed, you can conserve memory
            //resources.
            ////Disadvantages of Explicit Loading:
            //Increased Complexity as we need to explicitly manage the loading of related entities.
            //Additional queries. If not written properly, this may result in increased number of
            //database queries which impacts performance.

            /////LAZY LOADING 


            //How to implement Lazy Loading:
            //1.Install ther Nuget package Microsoft.EntityFrameworkCore.Proxies

            //2. Call the method UseLazyLoadingProxies() inside the OnConfiguring method of the DbContext class.

            //3.Change the reference type of ALL the navigation properties of the relevant entities to 'Virtual' like this:
            //public virtual Manager Manager { get; set; }
            //public virtual ICollection<Employee> Employees { get; set; }
            //etc

            //using (var context = new AppDBContext()) 
            //{ 
            //var manager = context.Managers.ToList();
            //    foreach (var mng in manager) 
            //    {
            //        Console.WriteLine($"Manager Full Name: {mng.MngFirstName} {mng.MngLastName}");
            //        if (mng.Employees.Any()) 
            //        {
            //            Console.WriteLine("Employees: ");
            //            foreach (var emp in mng.Employees) 
            //            {
            //                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            //            }
            //        }
            //    }
            //}


            /////ASYNCHRONOUS OPERATIONS
            //Asynchronous operations in Entity Framework allow database queries and updates to be performed
            //without blocking the application's main thread.By using methods with "Async" suffix,
            //the application can continue its tasks while waiting for the database operation to complete,
            //improving responsiveness and scalability.

            //When creating asynchronous methods
            //When working with asynchronous programming in C#, it's essential to follow certain conventions:
            //1.Methods performing asynchronous operations should be marked with the async keyword in their
            //declaration. 

            //2. Task or Task<T> Return Type: Asynchronous methods should return either a Task object or a
            //Task<T> object, where T is the type of the result. The Task object represents an asynchronous
            //operation that doesn't return a result, while Task<T> represents an asynchronous operation that
            //returns a result of type T.

            //When calling Asynchronous methods
            //1. Async/Await Pattern: When calling asynchronous methods, you should use the await keyword
            //before the method call. This tells the compiler to asynchronously wait for the completion of
            //the method before continuing execution.

            //2. Async Suffix: Methods that perform asynchronous operations typically have an "Async" suffix
            //added to their names to indicate that they execute asynchronously.

            //Mark with async keyword and modify return type to Task
            static async Task CreateEmployeeAsync (Employee employee) 
            {
                using (var context = new AppDBContext())
                { //always use the await keyword before the method call, in this case AddAsync() and SaveChangesAsync()
                    await context.Employees.AddAsync(employee);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Employee added successfully");
                }
            }

            //Now to call the method CreateEmployeeAsync() we need to use the await keyword before that method
            //as we did in the case of AddAsync() and SaveChangesAsync()
            //Note that in order to call an async method, you need to do so from within another asynchronous
            //method. If you try to use await outside of an asynchronous method, the compiler will give you an error.
            // So we have to change our main to "public static async Task Main(string[] args)"
            //Now let's call the method:
            await CreateEmployeeAsync(new Employee { FirstName = "John", LastName = "Holmes", EmpSalary = 50000, ManagerId = 1 });





        }
    }
}













