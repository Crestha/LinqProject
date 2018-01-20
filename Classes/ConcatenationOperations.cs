using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.Classes
{
    class ConcatenationOperations
    {
        // Concatenates two sequences to form one sequence.
        public void Concat()
        {
            List<string> str1 = new List<string> { "One", "Two" };
            List<string> str2 = new List<string> { "Three", "Four" };

            IEnumerable<string> concatStr = str1.Concat(str2);

            foreach (string str in concatStr)
            {
                Console.WriteLine(str);
            }
        }
    }
}
