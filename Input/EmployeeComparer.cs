using LinqProject.Model;
using System.Collections.Generic;

namespace LinqProject.Input
{
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x.EmployeeID == y.EmployeeID &&
                        x.FirstName.ToLower() == y.FirstName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.GetHashCode();
        }
    }
}
