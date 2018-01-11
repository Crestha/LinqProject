using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

//GroupBy,ToLookup
namespace LinqProject.Input
{
    //GroupBy & ToLookup return a collection that has a key and an inner collection based on a key field value.The execution of GroupBy is deferred whereas that of ToLookup is immediate.
    public class GroupingOperators
    {
        Employee employees = new Employee();
        Department departments = new Department();

        public void GroupByDepartmentNGenderOperator()
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
                                       EmployeeName = a.emp,
                                       DepartmentName = b == null ? "No Department" : b.DepartmentName
                                   }
                                   );


            var groupByDepartmentNGender = leftOuterJoin.GroupBy(x => new { x.DepartmentName, x.EmployeeName.Gender })
                                                        .Select(g => new
                                                        {
                                                            DepartmentName = g.Key.DepartmentName,
                                                            Gender = g.Key.Gender,
                                                            EmployeeName = g
                                                        });
            foreach (var item in groupByDepartmentNGender)
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine(item.Gender + "\t" + item.DepartmentName);

                foreach (var i in item.EmployeeName)
                {
                    Console.WriteLine(i.EmployeeName.FullName());
                }
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void GroupByOperator()
        {
            var groupedResult = employees.GetAllEmployee().GroupBy(e => e.Gender);

            foreach (var salaryGroup in groupedResult)
            {
                Console.WriteLine($"GroupBy Salary {salaryGroup.Key} : ");  //Each group has a key 

                foreach (Employee e in salaryGroup)  //Each group has a inner collection  
                    Console.WriteLine($"{e.FullName()}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void ToLookupOperator()
        {
            var lookupResult = employees.GetAllEmployee().ToLookup(e => e.Salary);

            foreach (var group in lookupResult)
            {
                Console.WriteLine($"ToLookup -GroupBy Salary {group.Key} : ");  //Each group has a key 

                foreach (Employee e in group)  //Each group has a inner collection  
                    Console.WriteLine($"{e.FullName()}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
