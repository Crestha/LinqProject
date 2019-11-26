using LinqProject.Model;
using System;
using System.Linq;

//Join(like inner join of SQL),GroupJoin(Equivalent to left outer join)
namespace LinqProject.QueryExpression
{
    // A join of two data sources is the association of objects in one data source with objects that share a common attribute in another data source.
    // In relational database terms, Join implements an inner join, a type of join in which only those objects that have a match in the other data set are returned. 
    // The GroupJoin method has no direct equivalent in relational database terms, but it implements a superset of inner joins and left outer joins. 
    // A left outer join is a join that returns each element of the first (left) data source, even if it has no correlated elements in the other data source.
    public class JoinCopy
    {
        Employee employees = new Employee();
        Department departments = new Department();

        //Join is like inner join of SQL. It returns a new collection that contains common elements from two collections whose keys matches.
        public void JoinOperators()
        {
            var innerJoin = employees.GetAllEmployee()//outer sequence
                                     .Join( //Join operates on two sequences inner sequence and outer sequence and produces a result sequence.
                                            departments.GetAllDepartment(),//inner sequence
                                            emp => emp.DepartmentID,//outerKeySelector
                                            dept => dept.DepartmentID,//innerKeySelector
                                            (employee, department) => new //result selector
                                            {
                                                EmpName = employee.FullName(),
                                                DeptName = department.DepartmentName
                                            }
                            );
            foreach (var join in innerJoin)
            {
                Console.WriteLine($"{join.EmpName} is in {join.DeptName} Department");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void GroupJoinOperators()
        {
            var groupJoin = departments.GetAllDepartment()//outer sequence
                                        .GroupJoin(
                                            employees.GetAllEmployee(),//inner sequence
                                            dept => dept.DepartmentID,//outerKeySelector
                                            emp => emp.DepartmentID,//innerKeySelector
                                            (deparment, employeeGroup) => new //result selector
                                            {
                                                DeptName = deparment.DepartmentName,
                                                EmpName = employeeGroup
                                            }
                            );
            foreach (var groupDept in groupJoin)
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine(groupDept.DeptName);
                Console.WriteLine("---------------------------------------------------------------------");

                foreach (var groupEmp in groupDept.EmpName)
                    Console.WriteLine(groupEmp.FullName());
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void LeftOuterJoinOperator()
        {
            var leftOuterJoin = employees.GetAllEmployee().GroupJoin(departments.GetAllDepartment(),
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
                                       EmployeeName = a.emp.FullName(),
                                       DepartmentName = b == null ? "No Department" : b.DepartmentName
                                   }
                                   );


            Console.WriteLine("Enter the name of the Department");
            string departmentName = Console.ReadLine();

            var count = leftOuterJoin.Where(x => x.DepartmentName == departmentName).Count();

            Console.WriteLine("leftOuterJoin: " + count);
            Console.WriteLine("---------------------------------------------------------------------");
        }

    }
}
