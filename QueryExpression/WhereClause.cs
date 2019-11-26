using LinqProject.Model;
using System;
using System.Collections;
using System.Linq;

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-clause
// The standard query operator methods that perform selection are: Where, OfType
namespace LinqProject.QueryExpression
{
    // Filtering refers to the operation of restricting the result set to contain only those elements that satisfy a specified condition. It is also known as selection.
    public class WhereClause
    {
        Employee employees = new Employee();
        // Selects values that are based on a predicate function.
        // Query expression may contain multiple where(Filter operator) clause. Where may contain multiple predicate subexpressions and it returns Boolean values. It cannot be positioned in the first or last clause.
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
        // Only valid for method query.
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
