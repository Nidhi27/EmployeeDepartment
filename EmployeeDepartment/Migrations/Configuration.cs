namespace EmployeeDepartment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EmployeeDepartment.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeDepartment.Models.EmployeeDepartmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeDepartment.Models.EmployeeDepartmentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Departments.AddOrUpdate(
                d => d.Id,
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" });

            context.Employees.AddOrUpdate(
              p => p.Id,
              new Employee {Id=1, Name = "Nidhi", City="Ahmedabad", DepartmentId=1},
              new Employee { Id = 2, Name = "Vraj", City = "Ahmedabad", DepartmentId = 1 },
              new Employee { Id = 3, Name = "Juhi", City = "Vadodara", DepartmentId = 2 }
            );

        }
    }
}
