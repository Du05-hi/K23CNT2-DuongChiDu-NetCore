using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuongChiDu_2310900022.Models;

namespace DuongChiDu_2310900022.Controllers
{
    public class DcdEmployeesController : Controller
    {
        private readonly DuongChiDu2310900022Context _context;

        public DcdEmployeesController(DuongChiDu2310900022Context context)
        {
            _context = context;
        }

        // GET: DcdEmployees
        public async Task<IActionResult> DcdIndex()
        {
            return View(await _context.DcdEmployees.ToListAsync());
        }

        // GET: DcdEmployees/Details/5
        public async Task<IActionResult> DcdDetails(int? dcdid)
        {
            if (dcdid == null)
            {
                return NotFound();
            }

            var dcdEmployee = await _context.DcdEmployees
                .FirstOrDefaultAsync(m => m.DcdEmpId == dcdid);
            if (dcdEmployee == null)
            {
                return NotFound();
            }

            return View(dcdEmployee);
        }

        // GET: DcdEmployees/Create
        public IActionResult DcdCreate()
        {
            return View();
        }

        // POST: DcdEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DcdCreate([Bind("DcdEmpId,DcdEmpName,DcdEmpLevel,DcdEmpStartDate,DcdEmpStatus")] DcdEmployee dcdEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dcdEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DcdIndex));
            }
            return View(dcdEmployee);
        }

        // GET: DcdEmployees/Edit/5
        public async Task<IActionResult> DcdEdit(int? dcdid)
        {
            if (dcdid == null)
            {
                return NotFound();
            }

            var dcdEmployee = await _context.DcdEmployees.FindAsync(dcdid);
            if (dcdEmployee == null)
            {
                return NotFound();
            }
            return View(dcdEmployee);
        }

        // POST: DcdEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DcdEdit(int dcdid, [Bind("DcdEmpId,DcdEmpName,DcdEmpLevel,DcdEmpStartDate,DcdEmpStatus")] DcdEmployee dcdEmployee)
        {
            if (dcdid != dcdEmployee.DcdEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dcdEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DcdEmployeeExists(dcdEmployee.DcdEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DcdIndex));
            }
            return View(dcdEmployee);
        }

        // GET: DcdEmployees/Delete/5
        public async Task<IActionResult> DcdDelete(int? dcdid)
        {
            if (dcdid == null)
            {
                return NotFound();
            }

            var dcdEmployee = await _context.DcdEmployees
                .FirstOrDefaultAsync(m => m.DcdEmpId == dcdid);
            if (dcdEmployee == null)
            {
                return NotFound();
            }

            return View(dcdEmployee);
        }

        // POST: DcdEmployees/Delete/5
        [HttpPost, ActionName("DcdDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int dcdid)
        {
            var dcdEmployee = await _context.DcdEmployees.FindAsync(dcdid);
            if (dcdEmployee != null)
            {
                _context.DcdEmployees.Remove(dcdEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DcdIndex));
        }

        private bool DcdEmployeeExists(int id)
        {
            return _context.DcdEmployees.Any(e => e.DcdEmpId == id);
        }
    }
}
