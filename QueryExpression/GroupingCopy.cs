using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that group data elements are: GroupBy, ToLookup.
namespace LinqProject.QueryExpression
{
    // Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute.
    // GroupBy & ToLookup return a collection that has a key and an inner collection based on a key field value.The execution of GroupBy is deferred whereas that of ToLookup is immediate.
    public class GroupingCopy
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

        // Groups elements that share a common attribute. Each group is represented by an IGrouping<TKey,TElement> object.
        public void GroupByOperator()
        {
            IEnumerable<IGrouping<string, Employee>> groupedResult = employees.GetAllEmployee().GroupBy(e => e.Gender);

            foreach (IGrouping<string, Employee> salaryGroup in groupedResult)
            {
                Console.WriteLine($"GroupBy Salary {salaryGroup.Key} : ");  //Each group has a key 

                foreach (Employee emp in salaryGroup)  //Each group has a inner collection  
                    Console.WriteLine($"{emp.FullName()}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        // Inserts elements into a Lookup<TKey,TElement> (a one-to-many dictionary) based on a key selector function.
        public void ToLookupOperator()
        {
            ILookup<int, Employee> lookupResult = employees.GetAllEmployee().ToLookup(e => e.Salary);

            foreach (IGrouping<int, Employee> group in lookupResult)
            {
                Console.WriteLine($"ToLookup -GroupBy Salary {group.Key} : ");  //Each group has a key 

                foreach (Employee emp in group)  //Each group has a inner collection  
                    Console.WriteLine($"{emp.FullName()}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
