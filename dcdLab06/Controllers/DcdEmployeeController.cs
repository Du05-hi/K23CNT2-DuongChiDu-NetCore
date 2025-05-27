using Microsoft.AspNetCore.Mvc;
using dcdLab06.Models;

namespace dcdLab06.Controllers
{
    public class DcdEmployeeController : Controller
    {
        private static List<DcdEmployee> dcdListEmployee = new List<DcdEmployee>()
        {
            new DcdEmployee {DcdId = 1, DcdName="Duong Chi Du", DcdBirthday= new DateTime(2005,07,30), DcdEmail="duongchidu30072005@gmail.com", DcdPhone="0365184434",DcdSalary=1200000,DcdStatus=true},
            new DcdEmployee {DcdId = 1, DcdName="Duong Chi Du", DcdBirthday= new DateTime(2005,07,30), DcdEmail="duongchidu30072005@gmail.com", DcdPhone="0365184434",DcdSalary=1200000,DcdStatus=true},
            new DcdEmployee {DcdId = 1, DcdName="Duong Chi Du", DcdBirthday= new DateTime(2005,07,30), DcdEmail="duongchidu30072005@gmail.com", DcdPhone="0365184434",DcdSalary=1200000,DcdStatus=true},
            new DcdEmployee {DcdId = 1, DcdName="Duong Chi Du", DcdBirthday= new DateTime(2005,07,30), DcdEmail="duongchidu30072005@gmail.com", DcdPhone="0365184434",DcdSalary=1200000,DcdStatus=true},

        };
        public IActionResult DcdIndex()
        {
            return View(dcdListEmployee);
        }
        
        public IActionResult DcdCreate()
        {
            return View();
        }
        public IActionResult DcdCreateSubmit(DcdEmployee dcdEmp)
        {
            dcdEmp.DcdId = dcdListEmployee.Max(e => e.DcdId) +1 ;
            dcdListEmployee.Add(dcdEmp);
            return RedirectToAction("DcdIndex");
        }

        [HttpGet]
        public IActionResult DcdEdit(int id)
        {
            var dcdEmp = dcdListEmployee.FirstOrDefault(e => e.DcdId == id);
            if (dcdEmp == null)
                return NotFound();
            return View(dcdEmp);
        }
        public IActionResult DcdEditPUT(DcdEmployee dcdEmp)
        {
            var existing = dcdListEmployee.FirstOrDefault(e => e.DcdId == dcdEmp.DcdId);
            if (existing != null)
            {
                existing.DcdName = dcdEmp.DcdName;
                existing.DcdBirthday = dcdEmp.DcdBirthday;
                existing.DcdEmail = dcdEmp.DcdEmail;
                existing.DcdPhone = dcdEmp.DcdPhone;
                existing.DcdSalary = dcdEmp.DcdSalary;
                existing.DcdStatus = dcdEmp.DcdStatus;
            }
            return RedirectToAction("DcdIndex");
        }

        public IActionResult DcdDelete(int id)
        {
            var dcdEmp = dcdListEmployee.FirstOrDefault(e => e.DcdId == id);
            if (dcdEmp != null)
                dcdListEmployee.Remove(dcdEmp);
            return RedirectToAction("DcdIndex");
        }
    }
}
    