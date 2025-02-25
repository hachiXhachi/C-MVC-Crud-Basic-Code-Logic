using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Employee Salary")]
        public int salary { get; set; }
        [Required]
        public string Department { get; set; }

        public int EmployeeID {get; set; }
        [ForeignKey("EmployeeID")]
        public Employee? employee { get; set; }

    }
}
