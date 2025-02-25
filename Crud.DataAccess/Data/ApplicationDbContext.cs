using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Employee> Emp { get; set; }
        public DbSet<Salary> sal { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {Id=1, Name="Jian", Age=22, EmployeeID = 1}
                );
            modelBuilder.Entity<Salary>().HasData(
                new Salary { Id = 1, Department = "Accounting", salary= 18000, EmployeeID=1}
                );
        }
    }
}
