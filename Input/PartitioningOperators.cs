using LinqProject.Model;
using System;
using System.Linq;

//Skip, SkipWhile, Take, TakeWhile
namespace LinqProject.Input
{
    class PartitioningOperators
    {
        //Takes elements up to a specified position starting from the first element in a sequence. 
        public void TakeOperator()
        {
            Employee employees = new Employee();
            var take = employees.GetAllEmployee().Take(3);
            Console.WriteLine("Take(3): Takes 3 elements from the start of a sequence: ");
            foreach (var item in take)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //Skips elements up to a specified position starting from the first element in a sequence.
        public void SkipOperator()
        {
            Employee employees = new Employee();
            var skip = employees.GetAllEmployee().Skip(3);
            Console.WriteLine("Skip(3): Skips 3 elements from the start and return remaining elements of a sequence: ");
            foreach (var item in skip)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //Returns elements from the first element until an element does not satisfy the condition. If the first element itself doesn't satisfy the condition then returns an empty collection. 
        public void TakeWhileOperator()
        {
            Employee employees = new Employee();
            var takeWhile = employees.GetAllEmployee().TakeWhile(x => x.FirstName.Length > 3);
            Console.WriteLine("TakeWhile() returns elements from a sequence as long as condition(FirstName.Length > 3) is true: ");
            foreach (var item in takeWhile)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //Skips elements based on a condition until an element does not satisfy the condition. If the first element itself doesn't satisfy the condition, it then skips 0 elements and returns all the elements in the sequence. 
        public void SkipWhileOperator()
        {
            Employee employees = new Employee();
            var skipWhile = employees.GetAllEmployee().SkipWhile(x => x.FirstName.Length > 3);
            Console.WriteLine("SkipWhile() bypasses elements in a sequence as long as condition(FirstName.Length > 3) is true and returns remaining elements: ");
            foreach (var item in skipWhile)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
