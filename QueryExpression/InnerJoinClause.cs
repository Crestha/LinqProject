using LinqProject.Model;
using System;
using System.Linq;

//Inner join,Group join,Left outer join
namespace LinqProject.QueryExpression
{
    class InnerJoinClause
    {
        //A join clause takes two source sequences as input.
        public void InnerJoinMain()
        {
            Employee employee = new Employee();
            Department department = new Department();

            // Query that selects a property from each element.
            var innerJoinQuery = from e in employee.GetAllEmployee()
                                 join d in department.GetAllDepartment()
                                 on e.DepartmentID equals d.DepartmentID
                                 select new { EmployeeName = e.FullName(), DepartmentName = d.DepartmentName };

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.EmployeeName + " " + item.DepartmentName);
            }
            Console.ReadLine();
        }
    }
}
