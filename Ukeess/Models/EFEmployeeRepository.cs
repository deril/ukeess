using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ukeess.Models
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        ApplicationDbContext context;

        public EFEmployeeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Employee> Employees =>
            context.Employees.Include(e => e.Department);

        public void SaveEmployee(Employee employee)
        {
            var dbEntry = context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (dbEntry != null)
            {
                dbEntry.Name = employee.Name;
                dbEntry.Active = employee.Active;
                dbEntry.DepartmentID = employee.DepartmentID;

                context.SaveChanges();
            }
        }

        public Employee DeleteEmployee(int employeeID)
        {
            var dbEntry = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
            if (dbEntry != null)
            {
                context.Employees.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
