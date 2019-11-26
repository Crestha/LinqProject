using System;
using System.Linq;

namespace LinqProject.QueryExpression
{
    // Let clause creates a new range variable and initializes it with the result of the expression you supply. Once initialized with a value, the range variable cannot be used to store another value. 
    class LetClause
    {
        //In the following example let is used in two ways:

        //1.To create an enumerable type that can itself be queried.

        //2.To enable the query to call ToLower only one time on the range variable word. Without using let, you would have to call ToLower in each predicate in the where clause.
        public void LetMain()
        {
            string[] strings =
            {
            "A penny saved is a penny earned.",
            "The early bird catches the worm.",
            "The pen is mightier than the sword."
            };

            // Split the sentence into an array of words
            // and select those whose first letter is a vowel.
            var earlyBirdQuery =
                from sentence in strings
                let words = sentence.Split(' ')
                from word in words
                let w = word.ToLower()
                where w[0] == 'a' || w[0] == 'e'
                    || w[0] == 'i' || w[0] == 'o'
                    || w[0] == 'u'
                select word;

            // Execute the query.
            foreach (var v in earlyBirdQuery)
            {
                Console.WriteLine("\"{0}\" starts with a vowel", v);
            }
            Console.ReadLine();
        }
    }
}
