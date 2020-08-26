using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData
                (
                new Employee()
                {
                    ID = 1,
                    FullName = "Anh Khoa",
                    Department = Department.IT,
                    Email = "anhkhoa@codegym.vn",
                    AvatarPath = "~/images/mangtae.jpg"
                },
                new Employee()
                {
                    ID = 2,
                    FullName = "Ý Nhi",
                    Department = Department.HR,
                    Email = "ynhi@codegym.vn",
                    AvatarPath = "~/images/mangtae.jpg"
                });
        }
    }
}
