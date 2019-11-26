using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.QueryExpression
{
    class Orderby
    {
        public void OrderbyMain()
        {
            Employee employees = new Employee();

            IEnumerable<Employee> queryOrderby = from e in employees.GetAllEmployee()
                                                 orderby e.FirstName
                                                 select e;

            foreach (var employee in queryOrderby)
            {
                Console.WriteLine(employee.FullName());
            }

            // Sorting first by LastName then by Gender
            var sortedGroups = from e in employees.GetAllEmployee()
                               orderby e.LastName
                               group e by e.Gender into newGroup
                               orderby newGroup.Key
                               select newGroup;

            Console.WriteLine("Sorted Employee Groups by Gender:");
            foreach (var employeeGroup in sortedGroups)
            {
                Console.WriteLine(employeeGroup.Key); //Gender
                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine("{0}, {1}", employee.FullName(), employee.Gender);
                }
            }

            Console.ReadLine();
        }
    }
}
