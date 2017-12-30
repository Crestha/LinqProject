using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

//Select,SelectMany
namespace LinqProject.Input
{
    class ProjectionOperators
    {
        Employee employees = new Employee();

        public void SelectOperator()
        {
            var query = employees.GetAllEmployee().Select(
                e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    Salary = e.Salary
                }
                );
            Console.WriteLine("Select method to project the FirstName and LastName properties to a seqence of anonymous types : ");

            foreach (var emp in query)
            {
                Console.WriteLine($"Employee FirstName: {emp.FirstName}, LastName: {emp.LastName}, Salary: {emp.Salary} and Gender: {emp.Gender}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        //SelectMany operator projects sequences of values that are based on a transform function and then flattens them into one sequence. 
        public void SelectManyOperator()
        {
            //Query Syntax
            List<string> words = new List<string>() { "an", "apple", "a", "day" };

            /*from word in words select word.Substring(0, 1);*/
            IEnumerable<string> querySelect = words.Select(s => s.Substring(0, 1));

            foreach (string s in querySelect)
                Console.WriteLine(s);
            Console.WriteLine("---------------------------------------------------------------------");

            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };

            /*from phrase in phrases from word in phrase.Split(' ') select word;*/
            IEnumerable<string> querySelectMany = phrases.SelectMany(s => s.Split(' '));

            foreach (string s in querySelectMany)
                Console.WriteLine(s);
            Console.WriteLine("---------------------------------------------------------------------");

            //Method Syntax
            List<Bouquet> bouquets = new List<Bouquet>() {
                            new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
                            new Bouquet{ Flowers = new List<string> { "tulip", "rose", "orchid" }},
                            new Bouquet{ Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
                            new Bouquet{ Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
            };

            // *********** Select ***********              
            IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

            // ********* SelectMany *********  
            IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

            Console.WriteLine("Results by using Select():");
            // Note the extra foreach loop here.  
            foreach (IEnumerable<String> collection in query1)
                foreach (string item in collection)
                    Console.WriteLine(item);
            Console.WriteLine("---------------------------------------------------------------------");

            Console.WriteLine("\nResults by using SelectMany():");
            foreach (string item in query2)
                Console.WriteLine(item);
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
