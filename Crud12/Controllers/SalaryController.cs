using Crud.DataAccess.Repository.IRepository;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Crud12.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public SalaryController(IUnitofWork iunitofwork)
        {
            _unitofWork = iunitofwork;
        }
        public IActionResult Index()
        {
            List<Salary> sal = _unitofWork.salaRepo.GetAll().ToList();
            return View(sal);
        }

        public IActionResult create()
        {
            IEnumerable<SelectListItem> EmployeesID = _unitofWork.empRepo.GetAll()
                .Select(s => new SelectListItem(
                    text: s.Name,
                    value: s.EmployeeID.ToString()
                    ));
            ViewBag.EmployeesId = EmployeesID;
            return View();
        }
        [HttpPost]
        public IActionResult create(Salary sal)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.salaRepo.add(sal);
                _unitofWork.save();
                TempData["success"] = "Successfully Created";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Salary sal = _unitofWork.salaRepo.GetEntitiy(s => s.Id == id);
            if(sal == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> EmployeesID = _unitofWork.empRepo.GetAll()
               .Select(s => new SelectListItem(
                   text: s.Name,
                   value: s.EmployeeID.ToString()
                   ));
            ViewBag.EmployeesId = EmployeesID;
            return View(sal);
        }

        //post
        [HttpPost]
        public IActionResult edit(Salary sal)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.salaRepo.update(sal);
                _unitofWork.save();
                TempData["success"] = "Successfully Updated";
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

            Salary sal = _unitofWork.salaRepo.GetEntitiy(s => s.Id == id);
            if (sal == null)
            {
                return NotFound();
            }
            return View(sal);
        }

        [HttpPost]
        public IActionResult delete(int id)
        {
            Salary sal = _unitofWork.salaRepo.GetEntitiy(s => s.Id == id);
            if (sal == null)
            {
                return NotFound();
            }
            _unitofWork.salaRepo.delete(sal);
            _unitofWork.save();
            TempData["success"] = "Successfully Deleted";
            return RedirectToAction("Index");
        }
    }
}
