using LinqProject.Model;
using System;
using System.Linq;

// The standard query operator methods for finding one item in collection are: ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault.
// Note: Not valid for query syntax.
namespace LinqProject.Classes
{
    // Element operations return a single, specific element from a sequence.
    public class ElementOperations
    {
        Employee employees = new Employee();

        // Returns the element at a specified index in a collection. It throws an exception if it's Index is out of range.
        public void ElementAt()
        {
            Employee query = employees.GetAllEmployee().ElementAt(0);
            Console.WriteLine($"ElementAt(0)-{query.FullName()} \"{query.Gender}\" Employee Salary is {query.Salary:C0}.");
        }

        // Returns the element at a specified index in a collection or a default value(0, null etc) if the index is out of range.
        public void ElementAtOrDefault()
        {
            Employee query = employees.GetAllEmployee().ElementAtOrDefault(7);
            Console.WriteLine($"ElementAtOrDefault(7)-{query.FullName()} \"{query.Gender}\" Employee Salary is {query.Salary:C0}.");
        }

        // Returns the first element of a collection, or the first element that satisfies a condition.
        public void First()
        {
            try
            {
                Console.WriteLine("Enter Initial letter or Full Name to Search first Matching Name in the Employee List: ");
                string name = Console.ReadLine();
                Employee query = employees.GetAllEmployee().First(e => e.FirstName.StartsWith(name, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"First()-First found matching Employee Name is: {query.FullName()}({query.Gender}).");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Returns the first element of a collection, or the first element that satisfies a condition. Returns a default value if no such element exists.
        public void FirstOrDefault()
        {
            Employee query = employees.GetAllEmployee().FirstOrDefault(e => e.Salary > 50000);
            Console.WriteLine($"FirstOrDefault()-First Employee in the list with salary > 50000 is {query.FullName()}.");
        }

        // Returns the last element of a collection, or the last element that satisfies a condition.
        public void Last()
        {
            Employee query = employees.GetAllEmployee().Last(e => e.Salary > 50000);
            Console.WriteLine($"Last()-Last Employee in the list with salary > 50000 is {query.FullName()}.");
        }

        // Returns the last element of a collection, or the last element that satisfies a condition. Returns a default value if no such element exists.
        public void LastOrDefault()
        {
            Employee query = employees.GetAllEmployee().LastOrDefault(e => e.Salary > 50000);
            Console.WriteLine($"LastOrDefault()-Last Employee in the list with salary > 50000 is {query.FullName()}.");
        }

        // Returns the only element of a collection, or the only element that satisfies a condition. Throws exception if there is more than one match.
        public void Single()
        {
            try
            {
                Employee query = employees.GetAllEmployee().Single(e => e.Salary > 55000);
                Console.WriteLine($"Single()-Single Employee with salary > 55000 is {query.FullName()}.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Returns the only element of a collection, or the only element that satisfies a condition. Returns a default value if no such element exists or the collection does not contain exactly one element.
        public void SingleOrDefault()
        {
            var query = employees.GetAllEmployee().SingleOrDefault(e => e.Salary > 55000);
            Console.WriteLine($"SingleOrDefault()-Employee with salary > 55000 is {query.FullName()}.");
        }

    }
}
