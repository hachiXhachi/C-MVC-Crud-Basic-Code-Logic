using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required][DisplayName("Employee Name")]
        public string Name { get; set; }
        [Range(1,150)]
        public int Age { get; set; }
    }
}
