using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaClick.Data;
using SistemaClick.Data.Entities;

namespace SistemaClick.Controllers
{
    public class CCFSController : Controller
    {
        private readonly DataContext _context;

        public CCFSController(DataContext context)
        {
            _context = context;
        }

        // GET: CCFS
        public async Task<IActionResult> Index()
        {
              return _context.CCF != null ? 
                          View(await _context.CCF.ToListAsync()) :
                          Problem("Entity set 'DataContext.CCF'  is null.");
        }

        // GET: CCFS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CCF == null)
            {
                return NotFound();
            }

            var cCF = await _context.CCF
                .FirstOrDefaultAsync(m => m.CCFId == id);
            if (cCF == null)
            {
                return NotFound();
            }

            return View(cCF);
        }

        // GET: CCFS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CCFS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CCFId,Nombre")] CCF cCF)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCF);
        }

        // GET: CCFS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CCF == null)
            {
                return NotFound();
            }

            var cCF = await _context.CCF.FindAsync(id);
            if (cCF == null)
            {
                return NotFound();
            }
            return View(cCF);
        }

        // POST: CCFS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CCFId,Nombre")] CCF cCF)
        {
            if (id != cCF.CCFId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CCFExists(cCF.CCFId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cCF);
        }

        // GET: CCFS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CCF == null)
            {
                return NotFound();
            }

            var cCF = await _context.CCF
                .FirstOrDefaultAsync(m => m.CCFId == id);
            if (cCF == null)
            {
                return NotFound();
            }

            return View(cCF);
        }

        // POST: CCFS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CCF == null)
            {
                return Problem("Entity set 'DataContext.CCF'  is null.");
            }
            var cCF = await _context.CCF.FindAsync(id);
            if (cCF != null)
            {
                _context.CCF.Remove(cCF);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CCFExists(int id)
        {
          return (_context.CCF?.Any(e => e.CCFId == id)).GetValueOrDefault();
        }
    }
}
