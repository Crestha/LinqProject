using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// The standard query operator methods that perform projection are: Select, SelectMany.
namespace LinqProject.QueryExpression
{
    // Projection refers to the operation of transforming an object into a new form that often consists only of those properties that will be subsequently used.
    // By using projection, you can construct a new type that is built from each object. You can project a property and perform a mathematical function on it. You can also project the original object without changing it.
    class SelectClause
    {
        Employee employees = new Employee();
        Department departments = new Department();

        // Select clause also provides a powerful mechanism for transforming (or projecting) source data into new types.
        public void SelectOperator()
        {
            // An anonymous type in the select clause and using an object initializer to initialize it with the appropriate properties from the source element. Since select is anonymous type we have to use var in query and in foreach
            var query = employees.GetAllEmployee().Select(
                e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    Salary = e.Salary
                }
                );
            Console.WriteLine("Select method to project the properties to a sequence of anonymous types : ");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}\n", "First Name", "Last Name", "Salary", "Gender");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var emp in query)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}\n", emp.FirstName, emp.LastName, emp.Salary, emp.Gender);
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        //SelectMany operator projects sequences of values that are based on a transform function and then flattens them into one sequence 
        public void SelectManyOperator()
        {
            var query = employees.GetAllEmployee().GroupJoin(departments.GetAllDepartment(),
                                    e => e.DepartmentID,
                                    d => d.DepartmentID,
                                    (emp, dept) => new
                                    {
                                        emp,
                                        dept
                                    })
                                    .SelectMany(z => z.dept.DefaultIfEmpty(),
                                    (a, b) => new
                                    {
                                        EmployeeName = a.emp,
                                        DepartmentName = b == null ? "No Department" : b.DepartmentName
                                    }
                                    );


            Console.WriteLine("{0,-30} {1}\n", "Employee Name", "Department Name");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (var item in query)
            {
                Console.WriteLine("{0,-30} {1}\n", item.EmployeeName.FullName(), item.DepartmentName);
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        public void SelectMOperator()
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
