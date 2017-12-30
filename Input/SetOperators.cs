using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;

//Distinct,Except,Intersect,Union
namespace LinqProject.Input
{
    public class SetOperators
    {
        Employee employees = new Employee();
        IList<string> strList1 = new List<string>() { "One", "One","Two", "Three","FOUR", "Four", "Five" };
        IList<string> strList2 = new List<string>() { "Two", "THREE", "Four", "Five", "Six", "Seven", "Eight" };

        //The Distinct extension method returns a new collection of unique elements from the given collection. 
        public void DistinctOperator()
        {
            var query = employees.GetAllEmployee().Distinct();
            Console.WriteLine("Distinct Employee List: ");
            foreach (var item in query)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");

            var distinctList = strList1.Distinct();
            Console.WriteLine("Distinct List from { \"One\", \"One\",\"Two\", \"Three\",\"FOUR\", \"Four\", \"Five\" }: ");
            foreach (var str in distinctList)
                Console.WriteLine(str);
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Except() method requires two collections. It returns a new collection with elements from the first collection which do not exist in the second collection (parameter collection). 
        public void ExceptOperator()
        {
            var result = strList1.Except(strList2);
            Console.WriteLine("Except(): First Collection { \"One\", \"One\",\"Two\", \"Three\",\"FOUR\", \"Four\", \"Five\" } which do not exist in the Second Collection { \"Two\", \"THREE\",\"Four\", \"Five\",\"Six\", \"Seven\", \"Eight\" }: ");
            foreach (string str in result)
                Console.WriteLine(str);
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Intersect extension method requires two collections. It returns a new collection that includes common elements that exists in both the collection.
        public void IntersectOperator()
        {
            var result = strList1.Intersect(strList2);
            Console.WriteLine("Intersect: Common elements that exists in both the collection { \"One\", \"One\",\"Two\", \"Three\",\"FOUR\", \"Four\", \"Five\" } { \"Two\", \"THREE\",\"Four\", \"Five\",\"Six\", \"Seven\", \"Eight\" }: ");
            foreach (string str in result)
                Console.WriteLine(str);
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        //The Union extension method requires two collections and returns a new collection that includes distinct elements from both the collections. 
        public void UnionOperator()
        {
            var result = strList1.Union(strList2);
            Console.WriteLine("Union: Includes distinct elements from both the collections{ \"One\", \"One\",\"Two\", \"Three\",\"FOUR\", \"Four\", \"Five\" }{ \"Two\", \"THREE\",\"Four\", \"Five\",\"Six\", \"Seven\", \"Eight\" }: ");
            foreach (string str in result)
                Console.WriteLine(str);
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}