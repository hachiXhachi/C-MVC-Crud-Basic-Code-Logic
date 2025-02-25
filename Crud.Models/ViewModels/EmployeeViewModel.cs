using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee emp { get; set; }
        IEnumerable<SelectListItem> SalaryList { get; set; }
    }
}
