using LinqProject.Model;
using System;
using System.Linq;

//Inner join,Group join,Left outer join
namespace LinqProject.QueryExpression
{
    class GroupJoinClause
    {
        //takes two source sequences as input.
        //A join clause with an 'into' expression is called a group join. // into(additional query)
        public void GroupJoinMain()
        {
            Employee employee = new Employee();
            Department department = new Department();

            //If no elements from the right source sequence are found to match an element in the left source, the join clause will produce an empty array for that item. 
            var groupJoinQuery = from e in employee.GetAllEmployee()
                                 join d in department.GetAllDepartment()
                                 on e.DepartmentID equals d.DepartmentID into departGroup
                                 select new { EmployeeName = e.FullName(), Departments = departGroup };

            // A nested foreach statement is required to access group items.
            foreach (var groupDepartment in groupJoinQuery)
            {
                Console.WriteLine(groupDepartment.EmployeeName);
                foreach (var dept in groupDepartment.Departments)
                {
                    Console.WriteLine(dept.DepartmentName);
                }
            }

            Console.ReadLine();
        }
    }
}
