using System.Collections.Generic;

namespace Ukeess.Models.ViewModels
{
    public class EmployeesListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
