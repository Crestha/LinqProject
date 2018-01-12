using System.Collections.Generic;

namespace LinqProject.Model
{
    public class Department
    {
        /// <summary>
        /// Type Members
        /// </summary>
        
        //Properties
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        //Method
        public List<Department> GetAllDepartment()
        {
            return new List<Department>()
            {
                new Department() { DepartmentID = 1, DepartmentName = "ACCOUNTS" },
                new Department() { DepartmentID = 2, DepartmentName = "IT" },
                new Department() { DepartmentID = 3, DepartmentName = "HR" }
            };
        }
    }
}
