using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that group data elements are: GroupBy(deferred), ToLookup(immediate).
namespace LinqProject.Classes
{
    // Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute.
    public class GroupingOperations
    {
        Employee employees = new Employee();
        Department departments = new Department();
        
        // Groups elements that share a common attribute. Each group is represented by an IGrouping<TKey,TElement> object.
        public void GroupBy()
        {
            IEnumerable<IGrouping<string,Employee>> groupedResult = employees.GetAllEmployee().GroupBy(e => e.Gender);

            foreach (IGrouping<string, Employee> salaryGroup in groupedResult)
            {
                Console.WriteLine($"GroupBy()- Group by Gender = {salaryGroup.Key} : ");  

                foreach (Employee emp in salaryGroup)  
                    Console.WriteLine($"{emp.FullName()}");
            }
        }

        // Inserts elements into a Lookup<TKey,TElement> (a one-to-many dictionary) based on a key selector function.
        public void ToLookup()
        {
            ILookup<int, Employee> lookupResult = employees.GetAllEmployee().ToLookup(e => e.Salary);

            Console.WriteLine("ToLookup()-Group by Salary: ");
            foreach (IGrouping<int, Employee> group in lookupResult)
            {
                Console.WriteLine($"{group.Key:C0} : ");

                foreach (Employee emp in group)   
                    Console.WriteLine("{0,20}",emp.FullName());
            }
        }
    }
}
