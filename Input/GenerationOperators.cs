using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

//DefaultIfEmpty,Empty,Range,Repeat
//NOTE: The Empty, Range & Repeat methods are not extension methods for IEnumerable or IQueryable but they are simply static methods defined in a static class Enumerable. 
namespace LinqProject.Input
{
    class GenerationOperators
    {
        //The DefaultIfEmpty() method returns a new collection with the default value if the given collection on which DefaultIfEmpty() is invoked is empty.
        public void DefaultIfEmptyOperator()
        {
            IList<string> emptyList = new List<string>();

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine($"Count: {newList1.Count()}");
            Console.WriteLine($"Value: {newList1.ElementAt(0)}");

            Console.WriteLine($"Count: {newList2.Count()}");
            Console.WriteLine($"Value: {newList2.ElementAt(0)}");

            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void EmptyOperator()
        {
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Employee>();

            Console.WriteLine($"Count: {emptyCollection1.Count()}");
            Console.WriteLine($"Type: {emptyCollection1.GetType().Name }");

            Console.WriteLine($"Count: {emptyCollection2.Count()}");
            Console.WriteLine($"Type: {emptyCollection2.GetType().Name}");

            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void RangeOperator()
        {
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine($"Total Count: {intCollection.Count()}");

            for (int i = 0; i<intCollection.Count(); i++)
                Console.WriteLine($"Value at index {i} : {intCollection.ElementAt(i) }");

            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void RepeatOperator()
        {
            var intCollection = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine($"Total Count: {intCollection.Count()}");

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine($"Value at index {i} : {intCollection.ElementAt(i)}");

            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
