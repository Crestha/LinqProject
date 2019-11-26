using LinqProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject.QueryExpression
{
    class FromClause
    {
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { EmployeeID = 1, FirstName = "Adam", LastName = "Maharjan", Gender="Male", Salary = 4000, DepartmentID = 1, Scores= new List<int> {97, 72, 81, 60}},
                new Employee() { EmployeeID = 2, FirstName = "Catherine", LastName = "Maharjan", Gender="Female",Salary = 5500, DepartmentID = 1, Scores= new List<int> {52, 72, 51, 60} },
                new Employee() { EmployeeID = 3, FirstName = "Elie", LastName = "Shrestha", Gender="Male", Salary = 54000, DepartmentID = 2, Scores= new List<int> {97, 72, 81, 90} },
                new Employee() { EmployeeID = 9, FirstName = "Empty", LastName = "Name", Gender="Male", Salary = 55000,Scores= new List<int> {57, 52, 81, 60} }
            };
            return employees;
        }
        public void FromMain()
        {
            Employee employee = new Employee();
            // Use a compound from to access the inner sequence within each element.i.e. scores inside Employee list
            // SelectMany()
            var scoreQuery = from e in employee.GetAllEmployee()
                             from score in e.Scores
                             where score > 90
                             select new { FirstName = e.FirstName, EmployeeScore = score };
            // Execute the queries.
            Console.WriteLine("scoreQuery:");
            foreach (var emp in scoreQuery)
            {
                Console.WriteLine("{0} Score: {1}", emp.FirstName, emp.EmployeeScore);
            }
            Console.ReadLine();
        }
}
}
