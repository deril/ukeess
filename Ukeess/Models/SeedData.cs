using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ukeess.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department { Name = "HR" },
                    new Department { Name = "Finance" },
                    new Department { Name = "Tech" }
                );
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var rnd = new Random();
                var maxDepartmentId = context.Departments.Count() + 1;

                context.Employees.AddRange(
                    new Employee { Name = "Lisa", Active = true, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Erik", Active = true, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Don", Active = true, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Peter", Active = false, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Maria", Active = false, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "John", Active = true, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Carlos", Active = true, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Helga", Active = true, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Bob", Active = false, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "James", Active = true, DepartmentID = rnd.Next(1, maxDepartmentId) },
                    new Employee { Name = "Ihor", Active = false, DepartmentID = rnd.Next(1, maxDepartmentId) }
                );
                context.SaveChanges();
            }
        }
    }
}
