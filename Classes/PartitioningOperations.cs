using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that partition sequences are: Take, TakeWhile, Skip, SkipWhile.
// Only valid in method query.
namespace LinqProject.Classes
{
    // Partitioning in LINQ refers to the operation of dividing an input sequence into two sections, without rearranging the elements, and then returning one of the sections.
    class PartitioningOperations
    {
        Employee employees = new Employee();

        // Takes elements up to a specified position starting from the first element in a sequence. 
        public void Take()
        {
            IEnumerable<Employee> take = employees.GetAllEmployee().Take(3);
            Console.WriteLine("Take(3): Takes 3 elements from the start of a sequence: ");
            foreach (Employee item in take)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        // Takes elements based on a predicate function until an element does not satisfy the condition. If the first element itself doesn't satisfy the condition then returns an empty collection. 
        public void TakeWhile()
        {
            IEnumerable<Employee> takeWhile = employees.GetAllEmployee().TakeWhile(x => x.FirstName.Length > 3);
            Console.WriteLine("TakeWhile(): returns elements from a sequence as long as condition(FirstName.Length > 3) is true: ");
            foreach (Employee item in takeWhile)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        // Skips elements up to a specified position in a sequence.
        public void Skip()
        {
            IEnumerable<Employee> skip = employees.GetAllEmployee().Skip(3);
            Console.WriteLine("Skip(3): Skips 3 elements from the start and returns remaining elements of a sequence: ");
            foreach (Employee item in skip)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        // Skips elements based on a predicate function until an element does not satisfy the condition. If the first element itself doesn't satisfy the condition, it then skips 0 elements and returns all the elements in the sequence. 
        public void SkipWhile()
        {
            IEnumerable<Employee> skipWhile = employees.GetAllEmployee().SkipWhile(x => x.FirstName.Length > 3);
            Console.WriteLine("SkipWhile(): bypasses elements in a sequence as long as condition(FirstName.Length > 3) is true and returns remaining elements: ");
            foreach (Employee item in skipWhile)
            {
                Console.WriteLine(item.FirstName);
            }
        }
    }
}
