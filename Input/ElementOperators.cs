using LinqProject.Model;
using System;
using System.Linq;

//finding one item in collection: ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault
namespace LinqProject.Input
{
    public class ElementOperators
    {
        Employee employees = new Employee();

        //ElementAt() throws an exception if it's Index is out of range
        public void ElementAtOperator()
        {
            var query = employees.GetAllEmployee().ElementAt(0);

            Console.WriteLine($"Using ElementAt(0): {query.FullName()} Employee is {query.Gender} and earns {query.Salary:C0}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //ElementAtOrDefault() gives the default value eg.0 for int, null for string etc if it's Index is out of range
        public void ElementAtOrDefaultOperator()
        {
            var query = employees.GetAllEmployee().ElementAtOrDefault(7);

            Console.WriteLine($"Using ElementAtOrDefault(7): {query.FullName()} Employee is {query.Gender} and earns {query.Salary:C0}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public void FirstOperator()
        {
            try
            {
                Console.WriteLine("Enter Initial letter or Full Name to Search first Matching Name in the Employee List: ");
                string name = Console.ReadLine();
                var query = employees.GetAllEmployee().First(e => e.FirstName.StartsWith(name, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"Employee Name: {query.FullName()}({query.Gender})");
                Console.WriteLine("--------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FirstOrDefaultOperator()
        {
            var query = employees.GetAllEmployee().FirstOrDefault(e => e.Salary > 50000);
            Console.WriteLine($"Using FirstOrDefault: First Employee in the list with salary > 50000 is {query.FullName()}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public void LastOperator()
        {
            var query = employees.GetAllEmployee().Last(e => e.Salary > 50000);
            Console.WriteLine($"Last Employee in the list with salary > 50000 is {query.FullName()}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public void LastOrDefaultOperator()
        {
            var query = employees.GetAllEmployee().LastOrDefault(e => e.Salary > 50000);
            Console.WriteLine($"Using LastOrDefault: Last Employee in the list with salary>50000 is {query.FullName()}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //throws exception if there is more than one match
        public void SingleOperator()
        {
            try
            {
                var query = employees.GetAllEmployee().SingleOrDefault(e => e.Salary > 55000);
                Console.WriteLine($"Single Employee with salary > 55000 is {query.FullName()}.");
                Console.WriteLine("--------------------------------------------------------------------------------------");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SingleOrDefaultOperator()
        {
            var query = employees.GetAllEmployee().SingleOrDefault(e => e.Salary > 55000);
            Console.WriteLine($"SingleOrDefault Employee with salary > 55000 is {query.FullName()}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

    }
}
