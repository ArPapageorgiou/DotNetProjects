using Entity_Framework_Core__Basics.Data;
using Entity_Framework_Core__Basics.Models;
//HOW TO ADD DATA TO DATABASE

//1)Create instances of your model classes 

//2)Add them to the appropriate DBSet property in your DBContext class

//Call the SaveChanges method


//to add data to the database we need to create an instance of AppDBContext so  that we can access it's
//properties. We do this with a using statement to make sure that the instance is properly disposed of 
//afterwards.
using (var context = new AppDBContext()) 
{
    //Insert manager details
    //var manager = new Manager();
    //manager.MngFirstName = "Ravi";
    //manager.MngLastName = "G";

    //add data to the DbSet
    //context.Managers.Add(manager);

    //The SaveChanges method passes data to the database
    /*context.SaveChanges();*/

    //Insert Employee details
    var employee = new Employee();
    employee.FirstName = "Argiris";
    employee.LastName = "Papageorgiou";
    employee.EmpSalary = 100000;
    employee.ManagerId = 1;

    context.Employees.Add(employee);

    context.SaveChanges();


}

