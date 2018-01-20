using LinqProject.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that perform selection are: Where, OfType
namespace LinqProject.Classes
{
    // Filtering refers to the operation of restricting the result set to contain only those elements that satisfy a specified condition. It is also known as selection.
    public class FilteringOperations
    {
        Employee employees = new Employee();

        // Selects values that are based on a predicate function.
        public void Where()
        {
            string gender = string.Empty;
            do
            {
                Console.WriteLine("Enter \"Male\" or \"Female\"");
                gender = Console.ReadLine().ToLower();
            }
            while (gender != "male" && gender != "female");
            IEnumerable<Employee> query = employees.GetAllEmployee().Where(e => e.Gender.ToLower() == gender);
            string g = gender.First().ToString().ToUpper() + gender.Substring(1);
            Console.WriteLine($"1. Where()-Filtered by Gender = \"{g}\" are : ");
            foreach (Employee emp in query)
            {
                Console.WriteLine($"{emp.FullName()}");
            }
        }

        // Selects values, depending on their ability to be cast to a specified type. Where and OfType extension methods can be called multiple times in a single LINQ query. 
        // Only valid for method query.
        public void OfType()
        {
            IList mixedList = new ArrayList
            {
                0,
                "One",
                "Two",
                3,
                new Department() { DepartmentID = 1, DepartmentName = "IT" }
            };
            IEnumerable<string> stringResult = from s in mixedList.OfType<string>()
                                               select s;

            IEnumerable<int> intResult = from s in mixedList.OfType<int>()
                                         select s;

            IEnumerable<Department> deptResult = from s in mixedList.OfType<Department>()
                                                 select s;

            Console.WriteLine("2. OfType<TResult>(): ");
            foreach (string str in stringResult)
                Console.WriteLine(str);

            foreach (int integer in intResult)
                Console.WriteLine(integer);

            foreach (Department dept in deptResult)
                Console.WriteLine(dept.DepartmentName);
        }
    }
}
