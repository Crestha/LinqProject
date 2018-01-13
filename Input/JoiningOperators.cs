using LinqProject.Model;
using System;
using System.Linq;

//Join(like inner join of SQL), GroupJoin(Equivalent to left outer join)
namespace LinqProject.Input
{
    public class JoiningOperators
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
    }
}
