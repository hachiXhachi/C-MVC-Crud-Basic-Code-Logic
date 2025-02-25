
using Crud.DataAccess.Data;
using Crud.DataAccess.Repository;
using Crud.DataAccess.Repository.IRepository;
using Crud.Models;
using Crud.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crud12.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitofWork _unitofwork;
        public EmployeeController(IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
        }
        public IActionResult Index()
        {
            List<Employee> emp = _unitofwork.empRepo.GetAll().ToList();
            ViewData["EmployeesId"] = _unitofwork.salaRepo.GetAll()
                .Select(s => new SelectListItem
                {
                    Text = s.Department,
                    Value = s.EmployeeID.ToString()
                }).ToList();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel

            return View(emp);
        }

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.empRepo.add(emp);
                _unitofwork.save();
                TempData["success"] = "Succesfully Created new Employee";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee? emp = _unitofwork.empRepo.GetEntitiy(u => u.Id == id);
            if (emp == null)
            {
                return NotFound();
              
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.empRepo.update(emp);
                _unitofwork.save();
                TempData["success"] = "Succesfully Updated new Employee";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee? emp = _unitofwork.empRepo.GetEntitiy(u => u.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult delete(int id)
        {
            Employee emp = _unitofwork.empRepo.GetEntitiy(u => u.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            _unitofwork.empRepo.delete(emp);
            _unitofwork.save();
            TempData["success"] = "Succesfully Deleted new Employee";
            return RedirectToAction("Index");
        }
    }
}
