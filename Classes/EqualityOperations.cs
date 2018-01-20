using LinqProject.Model;
using System;
using System.Linq;

// The SequenceEqual() checks whether the number of elements, value of each element and order of elements in two collections are equal or not. 
// Only valid for method query.
namespace LinqProject.Classes
{
    public class EqualityOperations
    {
        // Determines whether two sequences are equal by comparing elements in a pair-wise manner.
        public void SequenceEqual()
        {
            Employee employee1 = new Employee();
            Employee employee2 = new Employee();
            
            bool isEqual = employee1.GetAllEmployee().SequenceEqual(employee2.GetAllEmployee(), new EmployeeComparer()); 
            Console.WriteLine($"SequenceEqual()-Is the references of two objects are equal or not? {isEqual}"); 
        }
    }
}
