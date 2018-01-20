using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that perform generation are: DefaultIfEmpty, Empty, Range, Repeat.
// NOTE: The Empty, Range & Repeat methods are not extension methods for IEnumerable or IQueryable but they are simply static methods defined in a static class Enumerable. 
// Not valid for query syntax.
namespace LinqProject.Classes
{
    // Generation refers to creating a new sequence of values.
    class GenerationOperations
    {
        // Replaces an empty collection with a default valued singleton collection.
        // The DefaultIfEmpty() method returns a new collection with the default value if the given collection on which DefaultIfEmpty() is invoked is empty.
        public void DefaultIfEmpty()
        {
            IList<string> emptyList = new List<string>();

            IEnumerable<string> newList1 = emptyList.DefaultIfEmpty();
            IEnumerable<string> newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine($"Count: {newList1.Count()}");
            Console.WriteLine($"Value: {newList1.ElementAt(0)}");

            Console.WriteLine($"Count: {newList2.Count()}");
            Console.WriteLine($"Value: {newList2.ElementAt(0)}");
        }

        // Returns an empty collection.
        public void Empty()
        {
            IEnumerable<string> emptyCollection1 = Enumerable.Empty<string>();
            IEnumerable<Employee> emptyCollection2 = Enumerable.Empty<Employee>();

            Console.WriteLine($"Count: {emptyCollection1.Count()}");
            Console.WriteLine($"Type: {emptyCollection1.GetType().Name }");

            Console.WriteLine($"Count: {emptyCollection2.Count()}");
            Console.WriteLine($"Type: {emptyCollection2.GetType().Name}");
        }

        // Range Generates a collection that contains a sequence of numbers.
        public void Range()
        {
            char start = 'A';
            int count = 5;
            IEnumerable<int> intCollection = Enumerable.Range(start, count);
            Console.WriteLine($"Total Count: {intCollection.Count()}");

            for (int i = 0; i<intCollection.Count(); i++)
                Console.WriteLine($"Value at index {i} : {intCollection.ElementAt(i)}");
        }

        // Repeat Generates a collection that contains one repeated value.
        public void Repeat()
        {
            string repeatElement = "Repeat Me";
            int count = 5;
            IEnumerable<string> intCollection = Enumerable.Repeat(repeatElement, count);
            Console.WriteLine($"Total Count: {intCollection.Count()}");

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine($"Value at index {i} : {intCollection.ElementAt(i)}");
        }
    }
}
