using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that perform set operations are: Distinct(unique-1collection),Except(elements from 1 that is not in 2),Intersect(common elements in both),Union(unique elements from both).
// Only valid in method syntax.
namespace LinqProject.Classes
{
    public class SetOperations
    {
        Employee employees = new Employee();
        public List<Employee> GetAllEmployee2()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){ FirstName = "Geny" },
                new Employee(){ FirstName = "Enrique"},
                new Employee(){ FirstName = "Katrina"},
                new Employee(){ FirstName = "Geny"},
                new Employee(){ FirstName = "Johnson"}
            };
            return employees;
        }

        // Removes duplicate values from a collection.
        public void Distinct()
        {
            IEnumerable<Employee> query = employees.GetAllEmployee().Distinct();
            Console.WriteLine("1. Distinct()-Distinct Employee Name List: ");
            foreach (Employee names in query)
            {
                Console.WriteLine(names.FirstName);
            }
        }

        // The Except() method requires two collections. 
        // Returns the set difference, which means the elements of one collection that do not appear in a second collection.
        public void Except()
        {
            IEnumerable<string> employee1 = employees.GetAllEmployee().Select(e => e.FirstName);
            IEnumerable<string> employee2 = GetAllEmployee2().Select(e => e.FirstName);

            IEnumerable<string> query = employee1.Except(employee2);
            Console.WriteLine("2. Except()-Distinct Employee Names from the First collection that is not in the Second collection: ");
            foreach (string employeeList in query)
                Console.WriteLine(employeeList);
        }

        // The Intersect() requires two collections. 
        // Returns the set intersection, which means elements that appear in each of two collections.
        public void Intersect()
        {
            IEnumerable<string> employee1 = employees.GetAllEmployee().Select(e => e.FirstName);
            IEnumerable<string> employee2 = GetAllEmployee2().Select(e => e.FirstName);

            IEnumerable<string> query = employee1.Intersect(employee2);
            Console.WriteLine("3. Intersect()-Common Distinct Employee Names that exists in both the collection: ");
            foreach (string employeeList in query)
                Console.WriteLine(employeeList);
        }

        // The Union() requires two collections.
        // Returns the set union, which means unique elements that appear in either of two collections.
        public void Union()
        {
            IEnumerable<string> employee1 = employees.GetAllEmployee().Select(e => e.FirstName);
            IEnumerable<string> employee2 = GetAllEmployee2().Select(e => e.FirstName);

            IEnumerable<string> query = employee1.Union(employee2);
            Console.WriteLine("4. Union()-All Distinct Employee Names that exists in both the collection: ");
            foreach (string employeeList in query)
                Console.WriteLine(employeeList);
        }
    }
}