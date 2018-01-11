using LinqProject.Model;
using System;
using System.Linq;

//OrderBy,OrderByDecending,ThenBy,ThenByDescending,Reverse
namespace LinqProject.Input
{
    public class SortingOperators
    {
        Employee employees = new Employee();

        public void OrderByOperator()
        {
            var query = employees.GetAllEmployee().OrderBy(e => e.FirstName);
            Console.WriteLine("Order By First Name : ");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.Salary}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        public void OrderByDecendingOperator()
        {
            var query = employees.GetAllEmployee().OrderByDescending(e => e.FirstName);
            Console.WriteLine("Order By Descending First Name : ");
            foreach (var item in query)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        public void ThenByOperator()
        {
            var query = employees.GetAllEmployee().OrderBy(e => e.FirstName).ThenBy(e => e.Salary);
            Console.WriteLine("Order By First Name, Then By Salary : ");
            foreach (var item in query)
            {
                Console.WriteLine($"{ item.FirstName} { item.Salary}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        public void ThenByDescendingOperator()
        {
            var query = employees.GetAllEmployee().OrderBy(e => e.FirstName).ThenByDescending(e => e.Salary);
            Console.WriteLine("Order By First Name, Then By Descending Salary : ");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.Salary}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
    }
}
