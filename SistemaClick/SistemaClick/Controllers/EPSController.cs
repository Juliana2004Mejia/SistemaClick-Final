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
    public class EPSController : Controller
    {
        private readonly DataContext _context;

        public EPSController(DataContext context)
        {
            _context = context;
        }

        // GET: EPS
        public async Task<IActionResult> Index()
        {
              return _context.EPS != null ? 
                          View(await _context.EPS.ToListAsync()) :
                          Problem("Entity set 'DataContext.EPS'  is null.");
        }

        // GET: EPS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EPS == null)
            {
                return NotFound();
            }

            var ePS = await _context.EPS
                .FirstOrDefaultAsync(m => m.EPSId == id);
            if (ePS == null)
            {
                return NotFound();
            }

            return View(ePS);
        }

        // GET: EPS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EPS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EPSId,Nombre")] EPS ePS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ePS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ePS);
        }

        // GET: EPS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EPS == null)
            {
                return NotFound();
            }

            var ePS = await _context.EPS.FindAsync(id);
            if (ePS == null)
            {
                return NotFound();
            }
            return View(ePS);
        }

        // POST: EPS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EPSId,Nombre")] EPS ePS)
        {
            if (id != ePS.EPSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ePS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EPSExists(ePS.EPSId))
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
            return View(ePS);
        }

        // GET: EPS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EPS == null)
            {
                return NotFound();
            }

            var ePS = await _context.EPS
                .FirstOrDefaultAsync(m => m.EPSId == id);
            if (ePS == null)
            {
                return NotFound();
            }

            return View(ePS);
        }

        // POST: EPS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EPS == null)
            {
                return Problem("Entity set 'DataContext.EPS'  is null.");
            }
            var ePS = await _context.EPS.FindAsync(id);
            if (ePS != null)
            {
                _context.EPS.Remove(ePS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EPSExists(int id)
        {
          return (_context.EPS?.Any(e => e.EPSId == id)).GetValueOrDefault();
        }
    }
}
