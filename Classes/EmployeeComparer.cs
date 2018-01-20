using LinqProject.Model;
using System;
using System.Collections.Generic;

namespace LinqProject.Classes
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
