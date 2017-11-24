using System.Linq;
namespace Ukeess.Models
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }

        void SaveEmployee(Employee employee);

        Employee DeleteEmployee(int employeeID);
    }
}
