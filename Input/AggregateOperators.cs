using LinqProject.Model;
using System;
using System.Linq;

//Aggregate,Average,Count,LongCount,Max,Min,Sum
namespace LinqProject.Input
{
    public class AggregateOperators
    {
        Employee employees = new Employee();
        Department departments = new Department();

        public void Operator()
        {
            var employeeByDepartment = employees.GetAllEmployee().GroupBy(x => x.DepartmentID);
            var employeeDeparmentInfo = employees.GetAllEmployee().Join(departments.GetAllDepartment(),
                                               x => x.EmployeeID,
                                               y => y.DepartmentID,
                                               (x, y) => new
                                               {
                                                   Employees = x,
                                                   Departments = y
                                               }
                                               );
            foreach (var emp in employeeByDepartment)
            {
                var maxSalary = emp.Select(x => x.Salary).Max();

                foreach (var item in employeeDeparmentInfo)
                {
                    if (emp.Key == item.Departments.DepartmentID)
                    {
                        Console.WriteLine();
                        Console.WriteLine(item.Departments.DepartmentName + " Department");
                        Console.WriteLine();
                        Console.WriteLine("Employee Name \t Salary");
                        Console.WriteLine("---------------------------");
                    }
                }
                foreach (var e in emp)
                {
                    if (e.Salary >= maxSalary)
                    {
                        Console.WriteLine(e.FullName() + "\t" + e.Salary);
                    }
                }
            }
        }

        //Average extension method calculates the average of the numeric items in the collection.
        public void AverageOperator()
        {
            var avg = employees.GetAllEmployee().Average(e => e.Salary);
            Console.WriteLine($"Average: {avg}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Count operator returns the number of elements in the collection or number of elements that have satisfied the given condition.
        public void CountOperator()
        {
            var answer = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of the Department");
                string departmentName = Console.ReadLine();
                var n = departments.GetAllDepartment().Where(d => d.DepartmentName == departmentName.ToUpper()).FirstOrDefault();

                if (n != null)
                {
                    var employeeCount = employees.GetAllEmployee().Where(x => x.DepartmentID == n.DepartmentID).Select(x => x.FullName()).Count();
                    Console.WriteLine(employeeCount);
                }
                else
                {
                    Console.WriteLine("The name you have entered is invalid");
                }

                Console.WriteLine("Would you like to enter name again? YES OR NO");
                answer = Console.ReadLine();
            } while (answer.ToLower() == "yes");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Max operator returns the largest numeric element from a collection. 
        public void MaxOperator()
        {
            var maxSalary = employees.GetAllEmployee().Select(x => x.Salary).Max();
            var maxPaidEmployeeInfo = employees.GetAllEmployee().Where(x => x.Salary >= maxSalary)
                                                .Join(departments.GetAllDepartment(),
                                                x => x.EmployeeID,
                                                y => y.DepartmentID,
                                                (x, y) => new
                                                {
                                                    Employees = x,
                                                    Departments = y
                                                }
                                                );


            foreach (var info in maxPaidEmployeeInfo)
            {
                Console.WriteLine($"Max(),Join: {info.Employees.FullName()} is paid highest salary {maxSalary} (Department Name : {info.Departments.DepartmentName})");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        public void MinOperator()
        {
            var minSalary = employees.GetAllEmployee().Select(x => x.Salary).Min();
            var minPaidEmployeeInfo = employees.GetAllEmployee().Where(x => x.Salary <= minSalary)
                                                .Join(departments.GetAllDepartment(),
                                                x => x.EmployeeID,
                                                y => y.DepartmentID,
                                                (x, y) => new
                                                {
                                                    Employees = x,
                                                    Departments = y
                                                }
                                                );

            foreach (var info in minPaidEmployeeInfo)
            {
                Console.WriteLine($"Min(),Join: {info.Employees.FullName()} is paid lowest salary {minSalary} (Department Name : {info.Departments.DepartmentName})");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Sum() method calculates the sum of numeric items in the collection. 
        public void SumOperator()
        {
            var sumOfSalary = employees.GetAllEmployee().Sum(s => s.Salary);
            Console.WriteLine($"Sum of all Employee's Salary : {sumOfSalary}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
