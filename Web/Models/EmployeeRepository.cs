using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Web.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

        public EmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee()
                {
                    ID = 1,
                    FullName = "Anh Khoa",
                    Department = Department.IT,
                    Email = "anhkhoa@codegym.vn",
                    AvatarPath= "~/images/mangtae.jpg"
                },
                new Employee()
                {
                    ID = 2,
                    FullName = "Ý Nhi",
                    Department = Department.HR,
                    Email = "ynhi@codegym.vn",
                    AvatarPath= "~/images/mangtae.jpg"
                }
            };
        }

        public Employee Create(Employee employee)
        {
            employee.ID = ((employees != null && employees.Count > 1) ?  employees.Max(e => e.ID) + 1 : 1);
            employee.AvatarPath = "~/images/mangtae.jpg";
            employees.Add(employee);
            return employee;
        }

        public bool Delete(int id)
        {
            var deleteEmployee = Get(id);
            if(deleteEmployee != null)
            {
                employees.Remove(deleteEmployee);
                return true;
            }
            return false;
        }

        public Employee Edit(Employee employee)
        {
            var editEmployee = Get(employee.ID);
            editEmployee.FullName = employee.FullName;
            editEmployee.Email = employee.Email;
            editEmployee.Department = employee.Department;
            return editEmployee;
        }

        public Employee Get(int id)
        {
            return employees.FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Employee> Gets()
        {
            return employees;
        }

        
    }
}
