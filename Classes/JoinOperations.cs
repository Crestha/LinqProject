using LinqProject.Model;
using System;
using System.Linq;

// Join(like inner join of SQL),GroupJoin(Equivalent to left outer join).
namespace LinqProject.Classes
{
    // A join of two data sources is the association of objects in one data source with objects that share a common attribute in another data source.
    public class JoinOperations
    {
        Employee employees = new Employee();
        Department departments = new Department();

        // Joins two sequences based on key selector(inner and outer) functions and extracts pairs(result) of values.
        public void Join()
        {
            var innerJoin = employees.GetAllEmployee()//outer sequence
                                     .Join(
                                            departments.GetAllDepartment(),//inner sequence
                                            emp => emp.DepartmentID,//outerKeySelector
                                            dept => dept.DepartmentID,//innerKeySelector
                                            (employee, department) => new //result selector
                                            {
                                                EmpName = employee.FullName(),
                                                DeptName = department.DepartmentName
                                            }
                            );
            Console.WriteLine("Join(): ");
            foreach (var join in innerJoin)
            {
                Console.WriteLine($"{join.EmpName} is in {join.DeptName} Department");
            }
        }

        // Joins two sequences based on key selector functions and groups the resulting matches for each element.
        public void GroupJoin()
        {
            var groupJoin = departments.GetAllDepartment()
                                        .GroupJoin(
                                            employees.GetAllEmployee(),
                                            dept => dept.DepartmentID,
                                            emp => emp.DepartmentID,
                                            (deparment, employeeGroup) => new
                                            {
                                                DeptName = deparment.DepartmentName,
                                                EmpName = employeeGroup
                                            }
                            );
            Console.WriteLine("GroupJoin(): ");
            foreach (var groupDept in groupJoin)
            {
                Console.WriteLine(groupDept.DeptName);

                foreach (var groupEmp in groupDept.EmpName)
                    Console.WriteLine("{0,20}",groupEmp.FullName());
            }
        }
    }
}
