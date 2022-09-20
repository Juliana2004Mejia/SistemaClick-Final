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
    public class ARLSController : Controller
    {
        private readonly DataContext _context;

        public ARLSController(DataContext context)
        {
            _context = context;
        }

        // GET: ARLS
        public async Task<IActionResult> Index()
        {
              return _context.ARL != null ? 
                          View(await _context.ARL.ToListAsync()) :
                          Problem("Entity set 'DataContext.ARL'  is null.");
        }

        // GET: ARLS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ARL == null)
            {
                return NotFound();
            }

            var aRL = await _context.ARL
                .FirstOrDefaultAsync(m => m.ARLId == id);
            if (aRL == null)
            {
                return NotFound();
            }

            return View(aRL);
        }

        // GET: ARLS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ARLS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ARLId,Nombre")] ARL aRL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aRL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aRL);
        }

        // GET: ARLS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ARL == null)
            {
                return NotFound();
            }

            var aRL = await _context.ARL.FindAsync(id);
            if (aRL == null)
            {
                return NotFound();
            }
            return View(aRL);
        }

        // POST: ARLS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ARLId,Nombre")] ARL aRL)
        {
            if (id != aRL.ARLId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aRL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ARLExists(aRL.ARLId))
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
            return View(aRL);
        }

        // GET: ARLS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ARL == null)
            {
                return NotFound();
            }

            var aRL = await _context.ARL
                .FirstOrDefaultAsync(m => m.ARLId == id);
            if (aRL == null)
            {
                return NotFound();
            }

            return View(aRL);
        }

        // POST: ARLS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ARL == null)
            {
                return Problem("Entity set 'DataContext.ARL'  is null.");
            }
            var aRL = await _context.ARL.FindAsync(id);
            if (aRL != null)
            {
                _context.ARL.Remove(aRL);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ARLExists(int id)
        {
          return (_context.ARL?.Any(e => e.ARLId == id)).GetValueOrDefault();
        }
    }
}
