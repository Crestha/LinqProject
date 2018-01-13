using LinqProject.Model;
using System.Collections.Generic;
using System;

namespace LinqProject.Input
{
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (string.Equals(x.FirstName, y.FirstName, StringComparison.OrdinalIgnoreCase))
            //x.EmployeeID == y.EmployeeID && x.FirstName.ToLower() == y.FirstName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.GetHashCode();
        }
    }
}
