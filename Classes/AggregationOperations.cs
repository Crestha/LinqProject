using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that perform aggregation operations are: Aggregate,Average,Count,LongCount,Max,Min,Sum.
// NOTE: only valid for method query.
namespace LinqProject.Classes
{
    // An aggregation operation computes a single value from a collection of values.
    public class AggregationOperations
    {
        Employee employees = new Employee();
        Department departments = new Department();

        // Performs a custom aggregation operation on the values of a collection.
        public void Aggregate()
        {
            // Determine whether any string in the array is longer than "banana".
            IEnumerable<string> names = employees.GetAllEmployee().Select(e => e.FirstName);
            string[] strNames = names.ToArray();

            string longestName = strNames.Aggregate("Linq",
                                (longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                                strName => strName);

            Console.WriteLine("The Employee with the longest name is {0}.",longestName);
        }

        // Calculates the average value of a collection of values.
        public void Average()
        {
            double avg = employees.GetAllEmployee().Average(e => e.Salary);
            Console.WriteLine($"Average()-Average Salary: {avg:C}");
        }

        // Counts the elements in a collection, optionally only those elements that satisfy a predicate function.
        public void Count()
        {
            string answer = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of the Department(HR,IT,ACCOUNTS)");
                string departmentName = Console.ReadLine();
                Department selectedDepartment = departments.GetAllDepartment().Where(d => d.DepartmentName == departmentName.ToUpper()).FirstOrDefault();

                if (selectedDepartment != null)
                {
                    int employeeCount = employees.GetAllEmployee().Where(x => x.DepartmentID == selectedDepartment.DepartmentID).Select(x => x.FullName()).Count();
                    Console.WriteLine($"Count()-Numbers of Employee in {departmentName.ToUpper()} department is {employeeCount}.");
                }
                else
                {
                    Console.WriteLine("The name you have entered is invalid");
                }
                Console.WriteLine("Enter name again? YES OR NO");
                answer = Console.ReadLine();
            } while (answer.ToLower() == "yes");
        }

        // Counts the elements in a large collection, optionally only those elements that satisfy a predicate function.
        public void LongCount()
        {
            const int salary = 50000;
            long count = employees.GetAllEmployee().LongCount(e => e.Salary > salary);

            Console.WriteLine("LongCount()-There are {0} Employees over 50000 salary {1}.", count, salary);
        }

        // Determines the maximum value in a collection.
        public void Max()
        {
            int maxSalary = employees.GetAllEmployee().Max(x => x.Salary);
            var maxPaidEmployeeInfo = employees.GetAllEmployee().Where(x => x.Salary >= maxSalary)
                                     .Join(departments.GetAllDepartment(),
                                            emp => emp.DepartmentID,
                                            dept => dept.DepartmentID,
                                            (employee, department) => new
                                            {
                                                EmpInfo = employee,
                                                DeptName = department.DepartmentName
                                            }
                            );
            foreach (var info in maxPaidEmployeeInfo)
            {
                Console.WriteLine($"Max(), Join()- {info.EmpInfo.FullName()} in {info.DeptName} Department is paid highest salary {info.EmpInfo.Salary:C0}");
            }
        }

        // Determines the minimum value in a collection.
        public void Min()
        {
            int minSalary = employees.GetAllEmployee().Min(x => x.Salary);
            var minPaidEmployeeInfo = employees.GetAllEmployee().Where(x => x.Salary <= minSalary)
                                                .Join(departments.GetAllDepartment(),
                                                 emp => emp.DepartmentID,
                                                dept => dept.DepartmentID,
                                                (employee, department) => new
                                                {
                                                    Employees = employee,
                                                    Departments = department.DepartmentName
                                                }
                                                );

            foreach (var info in minPaidEmployeeInfo)
            {
                Console.WriteLine($"Min(),Join()- {info.Employees.FullName()} in {info.Departments} Department is paid lowest salary {info.Employees.Salary:C0}");
            }
        }

        // Calculates the sum of the values in a collection.
        public void Sum()
        {
            var sumOfSalary = employees.GetAllEmployee().Sum(s => s.Salary);
            Console.WriteLine($"Sum()-Sum of all Employee's Salary : {sumOfSalary:C0}");
        }
    }
}
