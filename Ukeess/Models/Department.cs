using System.ComponentModel.DataAnnotations.Schema;

namespace Ukeess.Models
{
    public class Department
    {
        [Column("dpID")]
        public int DepartmentID { get; set; }
        [Column("dpName")]
        public string Name { get; set; }
    }
}
