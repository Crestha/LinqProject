using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.QueryExpression
{
    // Group clause returns IEnumerable<IGrouping<TKey, TElement>>
    class GroupClause
    {
        public void GroupMain()
        {
            Employee employees = new Employee();

            //Group by TKey string LastName
            IEnumerable<IGrouping<string, Employee>> employeeQuery1 = from e in employees.GetAllEmployee()
                                                                      group e by e.LastName;
            foreach (IGrouping<string, Employee> employeeGroup in employeeQuery1)
            {
                Console.WriteLine(employeeGroup.Key);
                foreach (Employee employee in employeeGroup)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName);
                }
            }
            // If you want to perform additional query operations on each group, you can specify a temporary identifier to store the results by using the 'into' contextual keyword.When you use into, you must continue with the query, and eventually end it with either a select statement or another group clause.
            // Group by the first letter(TKey char) of last name
            IEnumerable<IGrouping<char, Employee>> employeeQuery2 = from e in employees.GetAllEmployee()
                                                                    group e by e.LastName[0] into g
                                                                    orderby g.Key
                                                                    select g;
            foreach (IGrouping<char, Employee> employeeGroup in employeeQuery2)
            {
                Console.WriteLine(employeeGroup.Key);
                foreach (Employee employee in employeeGroup)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName);
                }
            }

            //Group by TKey bool
            IEnumerable<IGrouping<bool, Employee>> booleanGroupQuery = from e in employees.GetAllEmployee()
                                                                       group e by e.Scores.Average() >= 80; // Pass or fail
            foreach (IGrouping<bool, Employee> employeeGroup in booleanGroupQuery)
            {
                Console.WriteLine(employeeGroup.Key == true ? "High averages" : "Low averages");
                foreach (Employee employee in employeeGroup)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName + ":" + employee.Scores.Average());
                }
            }

            //group by Composite keys
            var GroupQuery = from e in employees.GetAllEmployee()
                             group e by new { name = e.FullName(), Gender = e.Gender } into g
                             orderby g.Key.Gender
                             select g;
            foreach (var employeeKeys in GroupQuery)
            {
                Console.WriteLine(employeeKeys.Key.name + " " + employeeKeys.Key.Gender);
            }

            Console.ReadLine();
        }
    }
}
