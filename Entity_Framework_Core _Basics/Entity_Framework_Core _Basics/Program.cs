
﻿using Entity_Framework_Core__Basics.Models;
using Entity_Framework_Core__Basics.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Entity_Framework_Core__Basics
{
    class Program
    {
        static void Main(string[] args)
        {

            //HOW TO ADD DATA TO DATABASE

            //1)Create instances of your model classes 

            //2)Add them to the appropriate DBSet property in your DBContext class

            //Call the SaveChanges method


            //to add data to the database we need to create an instance of AppDBContext so  that we can access it's
            //properties. We do this with a using statement to make sure that the instance is properly disposed of 
            //afterwards.
            try 
            { 
            using (var context = new AppDBContext())
            {
                    try 
                    { 
                    using (var transaction = context.Database.BeginTransaction())
                    {
                            //Insert manager details
                            var manager = new Manager();
                            manager.MngFirstName = "Ravi";
                            manager.MngLastName = "G";
                            //add data to the DbSet
                            //context.Managers.Add(manager);

                            var manager2 = new Manager();
                            manager2.MngFirstName = "Sam";
                            manager2.MngLastName = "K";
                            //context.Managers.Add(manager2);

                            var employee = new Employee();
                            employee.FirstName = "Argiris";
                            employee.LastName = "Papageorgiou";
                            employee.EmpSalary = 100000;
                            employee.ManagerId = 1;
                            //context.Employees.Add(employee);

                            var employee2 = new Employee();
                            employee2.FirstName = "Giorgos";
                            employee2.LastName = "Papageorgiou";
                            employee2.EmpSalary = 120000;
                            employee2.ManagerId = 1;
                            //context.Employees.Add(employee2);

                            var project = new Project();
                            project.Name = "Development";
                            //context.Project.Add(project);

                            var employeeProject = new EmployeeProject();
                            employeeProject.ProjectId = 1;
                            employeeProject.EmployeeId = 2;
                            //context.EmployeeProjects.Add(employeeProject);

                            var employeeDetails = new EmployeeDetails();
                            employeeDetails.Address = "Sarakou";
                            employeeDetails.PhoneNumber = "12345098798";
                            employeeDetails.Email = "papagiorgio@ado.net";
                            employeeDetails.EmployeeId = 1;
                            context.EmployeeDetails.Add(employeeDetails);

                            var employeeDetails2 = new EmployeeDetails();
                            employeeDetails2.Address = "Gripari";
                            employeeDetails2.PhoneNumber = "4563798798";
                            employeeDetails2.Email = "giorgio90@ado.net";
                            employeeDetails2.EmployeeId = 2;
                            context.EmployeeDetails.Add(employeeDetails2);

                            //The SaveChanges method passes data to the database
                            context.SaveChanges();
                            //If all operations succeed then commit the transaction
                            transaction.Commit();
                    }
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }



            }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}













