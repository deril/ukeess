using System.Linq;

namespace Ukeess.Models
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        ApplicationDbContext context;

        public EFDepartmentRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Department> Departments => context.Departments;
    }
}
