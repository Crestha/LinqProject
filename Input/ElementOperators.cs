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

            Console.WriteLine($"{query.FullName()} ElementAt(0) Employee is {query.Gender} and earns {query.Salary:C}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //ElementAtOrDefault() gives the default value eg.0 for int, null for string etc if it's Index is out of range
        public void ElementAtOrDefaultOperator()
        {
            var query = employees.GetAllEmployee().ElementAtOrDefault(7);

            Console.WriteLine($"{query.FullName()} ElementAtOrDefault(7) Employee is {query.Gender} and earns {query.Salary:C}.");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public void FirstOperator()
        {
            try
            {
                Console.WriteLine("Enter Name to Check the First Employee: ");
                string name = Console.ReadLine();
                var query = employees.GetAllEmployee().First(e => e.FirstName.StartsWith(name, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"{query.FirstName} is the first Employee in the list and details are: {query.Gender} ,{query.Salary}...");
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
            Console.WriteLine($"FirstOrDefault Employee with salary>50000 is {query.FirstName}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public void LastOperator()
        {
            var query = employees.GetAllEmployee().Last(e => e.Salary > 50000);
            Console.WriteLine($"Last employee with salary>50000 is {query.FirstName}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public void LastOrDefaultOperator()
        {
            var query = employees.GetAllEmployee().LastOrDefault(e => e.Salary > 50000);
            Console.WriteLine($"Last employee with salary>50000 is {query.FirstName}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //throws exception if there is more than one match
        public void SingleOperator()
        {
            try
            {
                var query = employees.GetAllEmployee().SingleOrDefault(e => e.Salary > 55000);
                Console.WriteLine($"Single Employee with salary>55000 is {query.FirstName}");
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
            Console.WriteLine($"SingleOrDefault Employee with salary>55000 is {query.FirstName}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

    }
}
