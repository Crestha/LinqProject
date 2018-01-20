using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that perform quantifier operations are: All, Any, Contains.
// Only valid for method syntax. 
namespace LinqProject.Classes
{
    // Quantifier operations return a BOOLEAN value that indicates whether some or all of the elements in a sequence satisfy a condition.
    public class QuantifierOperations
    {
        Employee employees = new Employee();

        // Determines whether all the elements in a sequence satisfy a condition.
        public void All()
        {
            bool allEmployees = employees.GetAllEmployee().All(x => x.FirstName.Length > 1);
            if (allEmployees)
            {
                Console.WriteLine($"All()-Condition true?: {allEmployees}");

                Console.WriteLine("Employees with matching FirstName.Length > 1: ");
                IEnumerable<Employee> list = employees.GetAllEmployee().Where(x => x.FirstName.Length > 1);
                foreach (Employee all in list)
                {
                    Console.WriteLine(all.FullName());
                }
            }
            else
            {
                Console.WriteLine($"All()-Condition true?: {allEmployees}");
            }
        }

        // Determines whether any elements in a sequence satisfies a condition.
        public void Any()
        {
            bool anyEmployee = employees.GetAllEmployee().Any(x => x.FirstName.Length > 5);
            if (anyEmployee)
            {
                Console.WriteLine($"Any()-Condition true?: {anyEmployee}");

                Console.WriteLine("Employees with matching FirstName.Length > 5: ");
                IEnumerable<Employee> list = employees.GetAllEmployee().Where(x => x.FirstName.Length > 5);
                foreach (Employee any in list)
                {
                    Console.WriteLine(any.FirstName);
                }
            }
            else
            {
                Console.WriteLine($"Any()-Condition true?: {anyEmployee}");
            }
        }

        // Determines whether a sequence contains a specified element.
        public void Contains()
        {
            Employee employeeToFind = new Employee() { FirstName = "Elie" };
            bool containsEmployee = employees.GetAllEmployee().Contains(employeeToFind, new EmployeeComparer());
            if (containsEmployee)
            {
                Console.WriteLine($"Contains()-Condition true?: {containsEmployee}");
            }
            else
            {
                Console.WriteLine($"Contains()-Conditon true?: {containsEmployee}");
            }
        }
    }
}
