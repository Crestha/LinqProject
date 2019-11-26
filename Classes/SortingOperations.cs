using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that sort data are: OrderBy, OrderByDecending, ThenBy, ThenByDescending, Reverse.
namespace LinqProject.Classes
{
    public class SortingOperations
    {
        Employee employees = new Employee();

        // Sorts the values in ascending order. 
        public void OrderBy()
        {
            IOrderedEnumerable<Employee> query = employees.GetAllEmployee().OrderBy(e => e.FirstName);
            Console.WriteLine("1. OrderBy()-Sorting Employee Names in Ascending Order: ");
            foreach (Employee names in query)
            {
                //string interpolation
                Console.WriteLine($"{names.FullName()}");
            }
        }

        // Sorts values in descending order. Only valid in method syntax.
        public void OrderByDecending()
        {
            IOrderedEnumerable<Employee> query = employees.GetAllEmployee().OrderByDescending(e=>e.FirstName);
            Console.WriteLine("2. OrderByDescending()-Sorting Employee Names in Descending Order: ");
            foreach (Employee names in query)
            {
                Console.WriteLine($"{names.FullName()}");
            }
        }

        // Performs a secondary sort in ascending order. Only valid in method syntax.
        public void ThenBy()
        {
            IOrderedEnumerable<Employee> query = employees.GetAllEmployee().OrderBy(e => e.FirstName).ThenBy(e => e.Salary);
            Console.WriteLine("3. ThenBy()-Sorting Employee Names and then by Salary in Ascending Order: ");

            Console.WriteLine("{0,-30}{1}", "Sorting By First Name", "Then Sorting By Salary");
            foreach (Employee emp in query)
            {
                Console.WriteLine("{0,-40}{1:C0}", emp.FirstName, emp.Salary);
            }
        }

        // Performs a secondary sort in descending order. Only valid in method syntax.
        public void ThenByDescending()
        {
            IOrderedEnumerable<Employee> query = employees.GetAllEmployee().OrderBy(e => e.FirstName).ThenByDescending(e => e.Salary);
            Console.WriteLine("4. ThenByDescending()-Sorting Employee Names and then by Salary in Descending Order: ");

            Console.WriteLine("{0,-30}{1}", "Order By First Name", "Then Sorting By Salary");
            foreach (Employee emp in query)
            {
                Console.WriteLine("{0,-40}{1:C0}", emp.FirstName, emp.Salary);
            }
        }

        // Reverses the order of the elements in a collection. Only valid in method syntax.
        public void Reverse()
        {
            IEnumerable<string> query = employees.GetAllEmployee().Select(e => e.FirstName).Reverse();
            Console.WriteLine("5. Reverse()-Reverse order of Employee Names List: ");
            foreach (string names in query)
            {
                Console.WriteLine($"{names}");
            }
        }
    }
}
