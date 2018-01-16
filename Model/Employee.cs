using System.Collections.Generic;

namespace LinqProject.Model
{
    public class Employee
    {
        /// <summary>
        /// Type Members
        /// </summary>

        //Fields
        private string _FirstName;
        private string _LastName;

        //Properties
        public int EmployeeID { get; set; }
        public string FirstName {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        public int DepartmentID { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }

        //Methods
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public List<Employee> GetAllEmployee()
        {
            return new List<Employee>
            {
                new Employee() { EmployeeID = 1, FirstName = "Adam", LastName = "Maharjan", Gender="Male", Salary = 4000, DepartmentID = 1 },
                new Employee() { EmployeeID = 2, FirstName = "Catherine", LastName = "Maharjan", Gender="Female",Salary = 5500, DepartmentID = 1 },
                new Employee() { EmployeeID = 3, FirstName = "Elie", LastName = "Shrestha", Gender="Male", Salary = 54000, DepartmentID = 2 },
                new Employee() { EmployeeID = 4, FirstName = "Geny", LastName = "Shrestha", Gender="Female", Salary = 4000, DepartmentID = 2 },
                new Employee() { EmployeeID = 5, FirstName = "Enrique", LastName = "Aryal", Gender="Male", Salary = 2000, DepartmentID = 2 },
                new Employee() { EmployeeID = 6, FirstName = "Katrina", LastName = "Khanal", Gender="Female", Salary = 8000, DepartmentID = 3 },
                new Employee() { EmployeeID = 7, FirstName = "Geny", LastName = "Dongol", Gender="Female", Salary = 54000, DepartmentID = 3 },
                new Employee() { EmployeeID = 8, FirstName = "Oschar", LastName = "Gurung", Gender="Male", Salary = 56000, DepartmentID = 3 },
                new Employee() { EmployeeID = 9, FirstName = "Empty", LastName = "Name", Gender="Male", Salary = 55000 }
            };
        }
    }
}
