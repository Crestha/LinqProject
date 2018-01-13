using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

//Select,SelectMany
namespace LinqProject.Input
{
    class ProjectionOperators
    {
        Employee employees = new Employee();
        Department departments = new Department();

        public void SelectOperator()
        {
            var query = employees.GetAllEmployee().Select(
                e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    Salary = e.Salary
                }
                );
            Console.WriteLine("Select method to project the properties to a sequence of anonymous types : ");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}\n", "First Name", "Last Name", "Salary", "Gender");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var emp in query)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}\n",emp.FirstName, emp.LastName, emp.Salary, emp.Gender);
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        //SelectMany operator projects sequences of values that are based on a transform function and then flattens them into one sequence 
        public void SelectManyOperator()
        {
            var query = employees.GetAllEmployee().GroupJoin(departments.GetAllDepartment(),
                                    e => e.DepartmentID,
                                    d => d.DepartmentID,
                                    (emp, dept) => new
                                    {
                                        emp,
                                        dept
                                    })
                                    .SelectMany(z => z.dept.DefaultIfEmpty(),
                                    (a, b) => new
                                    {
                                        EmployeeName = a.emp,
                                        DepartmentName = b == null ? "No Department" : b.DepartmentName
                                    }
                                    );


            Console.WriteLine("{0,-30} {1}\n", "Employee Name", "Department Name");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (var item in query)
            {
                Console.WriteLine("{0,-30} {1}\n", item.EmployeeName.FullName(), item.DepartmentName);
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
