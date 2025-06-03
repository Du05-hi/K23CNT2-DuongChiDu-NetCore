using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dcdLab07.Models;


namespace dcdLab07.Controllers
{
    public class DcdEmployeeController : Controller
    {
        // Mock Data:
        private static List<DcdEmployee> dcdListEmployee = new List<DcdEmployee>()
        {
            new DcdEmployee
            {
                DcdId = 2310900,
                DcdName = "Duong Chi Du",
                DcdBirthDay = new DateTime(2005, 7, 30),
                DcdEmail = "duongchidu@gmail.com",
                DcdPhone = "0365184434",
                DcdSalary = 12000000m,
                DcdStatus = true
            },
            new DcdEmployee
            {
                DcdId = 2,
                DcdName = "Trần Thị B",
                DcdBirthDay = new DateTime(1992, 8, 15),
                DcdEmail = "tranthib@example.com",
                DcdPhone = "0912345678",
                DcdSalary = 13500000m,
                DcdStatus = true
            },
            new DcdEmployee
            {
                DcdId = 3,
                DcdName = "Lê Văn C",
                DcdBirthDay = new DateTime(1988, 3, 22),
                DcdEmail = "levanc@example.com",
                DcdPhone = "0934567890",
                DcdSalary = 10000000m,
                DcdStatus = false
            },
            new DcdEmployee
            {
                DcdId = 4,
                DcdName = "Phạm Thị D",
                DcdBirthDay = new DateTime(1995, 11, 5),
                DcdEmail = "phamthid@example.com",
                DcdPhone = "0976543210",
                DcdSalary = 15000000m,
                DcdStatus = true
            },
            
        };
        // GET: DcdEmployeeController
        public ActionResult DcdIndex()
        {
            return View(dcdListEmployee);
        }

        // GET: DcdEmployeeController/DcdDetails/5
        public ActionResult Details(int id)
        {
            var dcdEmployee = dcdListEmployee.FirstOrDefault(x => x.DcdId == id);
            return View(dcdEmployee);
        }

        // GET: DcdEmployeeController/DcdCreate
        public ActionResult DcdCreate()
        {
            var dcdEmployee = new DcdEmployee();
            return View(dcdEmployee);
        }

        // POST: DcdEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DcdCreate(DcdEmployee dcdModel)
        {
            try
            {
                // Thêm mới nhân viên vào list
                dcdModel.DcdId = dcdListEmployee.Max(x => x.DcdId) + 1;
                dcdListEmployee.Add(dcdModel);
                return RedirectToAction(nameof(DcdIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: DcdEmployeeController/DcdEdit/5
        public ActionResult DcdEdit(int id)
        {
            var dcdEmployee = dcdListEmployee.FirstOrDefault(x => x.DcdId == id);
            return View(dcdEmployee);
        }

        // POST: DcdEmployeeController/DcdEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DcdEdit(int id, DcdEmployee dcdModel)
        {
            try
            {
                for (int i = 0; i < dcdListEmployee.Count(); i++)
                {
                    if (dcdListEmployee[i].DcdId == id)
                    {
                        dcdListEmployee[i] = dcdModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(DcdIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: DcdEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DcdEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(); 
            }
        }
    }
}