using LinqProject.Model;
using System;
using System.Linq;

//Average,Count,Max,Min,Sum
namespace LinqProject.Input
{
    public class AggregateOperators
    {
        Employee employees = new Employee();
        Department departments = new Department();

       //Average extension method calculates the average of the numeric items in the collection.
        public void AverageOperator()
        {
            double avg = employees.GetAllEmployee().Average(e => e.Salary);
            Console.WriteLine($"Average: {avg:C}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Count operator returns the number of elements in the collection or number of elements that have satisfied the given condition.
        public void CountOperator()
        {
            string answer = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of the Department(HR,IT,ACCOUNTS)");
                string departmentName = Console.ReadLine();
                var selectedDepartment = departments.GetAllDepartment().Where(d => d.DepartmentName == departmentName.ToUpper()).FirstOrDefault();

                if (selectedDepartment != null)
                {
                    var employeeCount = employees.GetAllEmployee().Where(x => x.DepartmentID == selectedDepartment.DepartmentID).Select(x => x.FullName()).Count();
                    Console.WriteLine($"Number of Employees in {departmentName.ToUpper()} is {employeeCount}");
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
            int maxSalary = employees.GetAllEmployee().Max(x => x.Salary);
            var maxPaidEmployeeInfo = employees.GetAllEmployee().Where(x => x.Salary >= maxSalary)
                                                .Join(departments.GetAllDepartment(),
                                                emp => emp.DepartmentID,
                                                dept => dept.DepartmentID,
                                                (employee, department) => new
                                                {
                                                    Employees = employee,
                                                    Departments = department.DepartmentName
                                                }
                                                );


            foreach (var info in maxPaidEmployeeInfo)
            {
                Console.WriteLine($"using Max(),Join(): {info.Employees.FullName()} in {info.Departments} Department is paid highest salary {info.Employees.Salary:C0}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Min operator returns the smallest numeric element from a collection. 
        public void MinOperator()
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
                Console.WriteLine($"using Min(),Join(): {info.Employees.FullName()} in {info.Departments} Department is paid lowest salary {info.Employees.Salary:C0}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Sum() method calculates the sum of numeric items in the collection. 
        public void SumOperator()
        {
            int sumOfSalary = employees.GetAllEmployee().Sum(s => s.Salary);
            Console.WriteLine($"Sum of all Employee's Salary : {sumOfSalary:C0}");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
