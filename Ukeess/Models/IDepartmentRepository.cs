using System.Linq;
namespace Ukeess.Models
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> Departments { get; }
    }
}
