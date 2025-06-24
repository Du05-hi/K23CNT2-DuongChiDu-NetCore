using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DcdLesson10EF.Models;

namespace DcdLesson10EF.Controllers
{
    public class DcdCatesController : Controller
    {
        private readonly DcdLesson10DbContext _context;

        public DcdCatesController(DcdLesson10DbContext context)
        {
            _context = context;
        }

        // GET: DcdCates
        public async Task<IActionResult> DcdIndex()
        {
            return View(await _context.Cates.ToListAsync());
        }

        // GET: DcdCates/Details/5
        public async Task<IActionResult> DcdDetails(int? dcdid)
        {
            if (dcdid == null)
            {
                return NotFound();
            }

            var cate = await _context.Cates
                .FirstOrDefaultAsync(m => m.CateId == dcdid);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        // GET: DcdCates/DcdCreate
        public IActionResult DcdCreate()
        {
            return View();
        }

        // POST: DcdCates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DcdCreate([Bind("CateId,CateName,CateStatus")] Cate cate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DcdIndex));
            }
            return View(cate);
        }

        // GET: DcdCates/Edit/5
        public async Task<IActionResult> DcdEdit(int? dcdid)
        {
            if (dcdid == null)
            {
                return NotFound();
            }

            var cate = await _context.Cates.FindAsync(dcdid);
            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }

        // POST: DcdCates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DcdEdit(int dcdid, [Bind("CateId,CateName,CateStatus")] Cate cate)
        {
            if (dcdid != cate.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CateExists(cate.CateId))
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
            return View(cate);
        }

        // GET: DcdCates/Delete/5
        public async Task<IActionResult> DcdDelete(int? dcdid)
        {
            if (dcdid == null)
            {
                return NotFound();
            }

            var cate = await _context.Cates
                .FirstOrDefaultAsync(m => m.CateId == dcdid);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        // POST: DcdCates/Delete/5
        [HttpPost, ActionName("DcdDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int dcdid)
        {
            var cate = await _context.Cates.FindAsync(dcdid);
            if (cate != null)
            {
                _context.Cates.Remove(cate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DcdIndex));
        }

        private bool CateExists(int id)
        {
            return _context.Cates.Any(e => e.CateId == id);
        }
    }
}
