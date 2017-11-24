using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ukeess.Models
{
    public class Employee
    {
        [Column("empID")]
        public int EmployeeID { get; set; }
        [Column("empName")]
        public string Name { get; set; }
        [Column("empActive")]
        public bool Active { get; set; }

        [Column("emp_dpID")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
