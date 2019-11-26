using LinqProject.Model;
using System;
using System.Linq;

//Inner join,Group join,Left outer join
namespace LinqProject.QueryExpression
{
    class LeftOuterJoinClause //into(additional query), DefaultIfEmpty
    {
        //takes two source sequences as input.
        //In a left outer join, all the elements in the left source sequence are returned, even if no matching elements are in the right sequence. 
        //To perform a left outer join in LINQ, use the DefaultIfEmpty method in combination with a group join to specify a default right-side element to produce if a left-side element has no matches. 
        //You can use null as the default value for any reference type, or you can specify a user-defined default type. In the following example, a user-defined default type is shown:
        public void LeftOuterJoinMain()
        {
            Employee employee = new Employee();
            Department department = new Department();

            var leftOuterJoinQuery = from e in employee.GetAllEmployee() //outer source
                                     join d in department.GetAllDepartment() //inner source
                                     on e.DepartmentID equals d.DepartmentID into departGroup
                                     from item in departGroup.DefaultIfEmpty(new Department { DepartmentName = String.Empty, DepartmentID = 0 })
                                     select new { EmployeeName = e.FullName(), DepartmentName = item.DepartmentName };
            foreach (var groupDepartment in leftOuterJoinQuery)
            {
                Console.WriteLine(groupDepartment.EmployeeName + ":" + groupDepartment.DepartmentName);
            }

            Console.ReadLine();
        }
    }
}
