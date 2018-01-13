using LinqProject.Model;
using System;
using System.Linq;

//All, Any, Contains
//NOTE: Quantifier operators are Not Supported with C# query syntax. 
namespace LinqProject.Input
{
    public class QuantifierOperators
    {
        Employee employees = new Employee();

        //The All operator evalutes each elements in the given collection on a specified condition and returns True if all the elements satisfy a condition.
        public void AllOperators()
        {
            bool allOperator = employees.GetAllEmployee().All(x => x.FirstName.Length > 1);
            if (allOperator)
            {
                Console.WriteLine($"All Operators true?: {allOperator}");

                Console.WriteLine("Employees with matching FirstName.Length > 1");
                var list = employees.GetAllEmployee().Where(x => x.FirstName.Length > 1);
                foreach (var all in list)
                {
                    Console.WriteLine(all.FullName());
                }
            }
            else
            {
                Console.WriteLine($"All Operators false?: {allOperator}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        //Any checks whether any element satisfy given condition or not? 
        public void AnyOperators()
        {
            bool anyOperator = employees.GetAllEmployee().Any(x => x.FirstName.Length > 5);
            if (anyOperator)
            {
                Console.WriteLine($"Any Operators true?: {anyOperator}");

                Console.WriteLine("Employees with matching FirstName.Length > 5");
                var list = employees.GetAllEmployee().Where(x => x.FirstName.Length > 5);
                foreach (var any in list)
                {
                    Console.WriteLine(any.FirstName);
                }
            }
            else
            {
                Console.WriteLine($"Any Operators false?: {anyOperator}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        //The Contains operator checks whether a specified element exists in the collection or not and returns a boolean.
        public void ContainsOperators()
        {
            var employeeToFind = new Employee() { FirstName = "Elie" };
            bool containsEmployee = employees.GetAllEmployee().Contains(employeeToFind, new EmployeeComparer());
            if (containsEmployee)
            {
                Console.WriteLine($"Contain Operators true?: {containsEmployee}");
            }
            else
            {
                Console.WriteLine($"Contain Operators false?: {containsEmployee}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
