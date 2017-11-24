using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ukeess.Models.ViewModels
{
    public class EmployeeEditViewModel
    {
		public Employee Emloyee { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
