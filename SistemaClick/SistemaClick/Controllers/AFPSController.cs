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
    public class AFPSController : Controller
    {
        private readonly DataContext _context;

        public AFPSController(DataContext context)
        {
            _context = context;
        }

        // GET: AFPS
        public async Task<IActionResult> Index()
        {
              return _context.AFP != null ? 
                          View(await _context.AFP.ToListAsync()) :
                          Problem("Entity set 'DataContext.AFP'  is null.");
        }

        // GET: AFPS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AFP == null)
            {
                return NotFound();
            }

            var aFP = await _context.AFP
                .FirstOrDefaultAsync(m => m.AFPId == id);
            if (aFP == null)
            {
                return NotFound();
            }

            return View(aFP);
        }

        // GET: AFPS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AFPS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AFPId,Nombre")] AFP aFP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aFP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aFP);
        }

        // GET: AFPS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AFP == null)
            {
                return NotFound();
            }

            var aFP = await _context.AFP.FindAsync(id);
            if (aFP == null)
            {
                return NotFound();
            }
            return View(aFP);
        }

        // POST: AFPS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AFPId,Nombre")] AFP aFP)
        {
            if (id != aFP.AFPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aFP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AFPExists(aFP.AFPId))
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
            return View(aFP);
        }

        // GET: AFPS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AFP == null)
            {
                return NotFound();
            }

            var aFP = await _context.AFP
                .FirstOrDefaultAsync(m => m.AFPId == id);
            if (aFP == null)
            {
                return NotFound();
            }

            return View(aFP);
        }

        // POST: AFPS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AFP == null)
            {
                return Problem("Entity set 'DataContext.AFP'  is null.");
            }
            var aFP = await _context.AFP.FindAsync(id);
            if (aFP != null)
            {
                _context.AFP.Remove(aFP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AFPExists(int id)
        {
          return (_context.AFP?.Any(e => e.AFPId == id)).GetValueOrDefault();
        }
    }
}
