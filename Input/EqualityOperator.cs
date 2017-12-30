using LinqProject.Model;
using System;
using System.Linq;

//There is only one equality operator: SequenceEqual. The SequenceEqual method checks whether the number of elements, value of each element and order of elements in two collections are equal or not. 
namespace LinqProject.Input
{
    public class EqualityOperator
    {
        public void SequenceEqualOperator()
        {
            Employee employee1 = new Employee();
            Employee employee2 = new Employee();
            
            bool isEqual = employee1.GetAllEmployee().SequenceEqual(employee2.GetAllEmployee(), new EmployeeComparer()); 
            Console.WriteLine($"Is the references of two objects are equal or not? {isEqual}"); //returns true
        }
    }
}
