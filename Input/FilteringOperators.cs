using LinqProject.Model;
using System;
using System.Collections;
using System.Linq;

//Where, OfType, Where..Contains
namespace LinqProject.Input
{
    public class FilteringOperators
    {
        Employee employees = new Employee();

        //The Where operator filters the collection based on a predicate function or given criteria.
        public void WhereOperator()
        {
            string gender = string.Empty;
            do
            {
                Console.WriteLine("Enter the 'Male' or 'Female'");
                gender = Console.ReadLine().ToLower();
            }
            while (gender != "male" && gender != "female");
            
            var query = employees.GetAllEmployee().Where(e => e.Gender.ToLower() == gender);
            Console.WriteLine($"Filtered by Gender = '{gender.ToUpper()}' are : ");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.FullName()}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        //The OfType operator filters the collection based on a given type. Where and OfType extension methods can be called multiple times in a single LINQ query.
        public void OfTypeOperator()
        {
            IList mixedList = new ArrayList
            {
                0,
                "One",
                "Two",
                3,
                new Department() { DepartmentID = 1, DepartmentName = "IT" }
            };
            var stringResult = from s in mixedList.OfType<string>()
                               select s;

            var intResult = from s in mixedList.OfType<int>()
                            select s;

            var deptResult = from s in mixedList.OfType<Department>()
                            select s;

            Console.WriteLine("OfType<TResult>(): ");

            foreach (var str in stringResult)
                Console.WriteLine(str);

            foreach (var integer in intResult)
                Console.WriteLine(integer);

            foreach (var dept in deptResult)
                Console.WriteLine(dept.DepartmentName);

            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
