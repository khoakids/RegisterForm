using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public SqlEmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Employee Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public bool Delete(int id)
        {
            var deleteEmployee = context.Employees.Find(id);
            if(deleteEmployee != null)
            {
                context.Employees.Remove(deleteEmployee);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Employee Edit(Employee employee)
        {
            var editEmployee = context.Employees.Attach(employee);
            editEmployee.State = EntityState.Modified;
            context.SaveChanges();
            return employee;
        }

        public Employee Get(int id)
        {
            return context.Employees.Find(id);
        }

        public IEnumerable<Employee> Gets()
        {
            return context.Employees;
        }
    }
}
