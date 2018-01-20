using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that perform projection are: Select, SelectMany.
namespace LinqProject.Classes
{
    // Projection refers to the operation of transforming an object into a new form that often consists only of those properties that will be subsequently used.
    // By using projection, you can construct a new type that is built from each object. You can project a property and perform a mathematical function on it. You can also project the original object without changing it.
    public class ProjectionOperations
    {
        Employee employees = new Employee();
        Department departments = new Department();

        // Projects values that are based on a transform function.
        public void Select()
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
            Console.WriteLine("Select() to project the properties to a sequence of anonymous types : ");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}\n", "First Name", "Last Name", "Salary", "Gender");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var emp in query)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-10:C0} {3,-10}\n",emp.FirstName, emp.LastName, emp.Salary, emp.Gender);
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        // Projects sequences of values that are based on a transform function and then flattens them into one sequence.
        public void SelectMany()
        {
            var query = employees.GetAllEmployee().GroupJoin(departments.GetAllDepartment(),
                                    e => e.DepartmentID,
                                    d => d.DepartmentID,
                                    (emp, dept) => new
                                    {
                                        emp,
                                        dept
                                    })
                                    .SelectMany(s => s.dept.DefaultIfEmpty(),
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
        }
    }
}
