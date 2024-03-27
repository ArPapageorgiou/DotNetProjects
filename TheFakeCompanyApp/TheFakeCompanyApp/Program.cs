
﻿using System.Linq;
using TCPData;

namespace TheFakeCompanyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //List<Employee> employeeList = Data.GetEmployees();
            //var filteredEmployees = employeeList.Filter(emp => emp.AnnualSalary < 50000);

            //foreach (var employee in filteredEmployees) 
            //{ 
            //    Console.WriteLine($"First Name: {employee.FirstName}");
            //    Console.WriteLine($"Last Name: {employee.LastName}");
            //    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            //    Console.WriteLine($"Manager: {employee.IsManager}");
            //}
            //Console.WriteLine();

            //List<Department> DepartmentList = Data.GetDepartment();
            //var filteredDepartment = DepartmentList.Where(dept => dept.ShortName == "HR" || dept.ShortName == "TE" );

            //foreach (var department in filteredDepartment)
            //{
            //    Console.WriteLine($"Department ID: {department.Id}");
            //    Console.WriteLine($"Long Name: {department.LongName}");
            //    Console.WriteLine($"Short Name: {department.ShortName}");
            //}

            List<Employee> employeeList = Data.GetEmployees();
            List<Department> DepartmentList = Data.GetDepartment();

            var resultList = from emp in employeeList
                             join dept in DepartmentList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = dept.LongName
                             };

            foreach (var employee in resultList)
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine($"Manager: {employee.Manager}");
                Console.WriteLine($"Department: {employee.Department}");
            }

            Console.WriteLine();

            var averageAnnualSalary = resultList.Average(a => a.AnnualSalary);
            var highestAnnualSalary = resultList.Max(a => a.AnnualSalary);
            var lowestAnnualSalary = resultList.Min(a => a.AnnualSalary);

            Console.WriteLine($"Average Annual Salary: {averageAnnualSalary}");
            Console.WriteLine($"Highest Annual Salary: {highestAnnualSalary}");
            Console.WriteLine($"Lowest Annual Salary: {lowestAnnualSalary}");

            Console.WriteLine();


        }
    }
}
