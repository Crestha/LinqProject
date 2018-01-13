using LinqProject.Model;
using System;
using System.Linq;

//OrderBy,OrderByDecending,ThenBy,ThenByDescending,Reverse
namespace LinqProject.Input
{
    public class SortingOperators
    {
        Employee employees = new Employee();

        //Sorts the elements in the collection based on specified fields in ascending order. 
        public void OrderByOperator()
        {
            var query = employees.GetAllEmployee().OrderBy(e => e.FirstName);
            Console.WriteLine("Sorting First Name in Ascending Order - OrderBy: ");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.FullName()}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        //Sorts the collection based on specified fields in descending order. Only valid in method syntax. 
        public void OrderByDecendingOperator()
        {
            var query = employees.GetAllEmployee().OrderByDescending(e => e.FirstName);
            Console.WriteLine("Sorting First Name in Descending Order - OrderByDescending: ");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.FullName()}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        //Only valid in method syntax. Used for second level sorting in ascending order. 
        public void ThenByOperator()
        {
            var query = employees.GetAllEmployee().OrderBy(e => e.FirstName).ThenBy(e => e.Salary);
            Console.WriteLine("{0,-30}{1}","Order By First Name", "Then By Salary");
            foreach (var item in query)
            {
                Console.WriteLine("{0,-30}{1}", item.FirstName, item.Salary);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        //Only valid in method syntax. Used for second level sorting in descending order.
        public void ThenByDescendingOperator()
        {
            var query = employees.GetAllEmployee().OrderBy(e => e.FirstName).ThenByDescending(e => e.Salary);
            Console.WriteLine("{0,-30}{1}", "Order By First Name", "Then By Descending Salary");
            foreach (var item in query)
            {
                Console.WriteLine("{0,-30}{1}", item.FirstName, item.Salary);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        //Only valid in method syntax.Sorts the collection in reverse order. 
        public void ReverseOperator()
        {
            var query = employees.GetAllEmployee().Select(e=>e.FirstName).Reverse();
            Console.WriteLine("Reverse order of Employee List: ");
            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
    }
}
