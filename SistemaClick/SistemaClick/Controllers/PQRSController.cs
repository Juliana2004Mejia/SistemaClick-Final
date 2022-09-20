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
    public class PQRSController : Controller
    {
        private readonly DataContext _context;

        public PQRSController(DataContext context)
        {
            _context = context;
        }

        // GET: PQRS
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.PQRS.Include(p => p.Cliente);
            return View(await dataContext.ToListAsync());
        }

        // GET: PQRS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PQRS == null)
            {
                return NotFound();
            }

            var pQRS = await _context.PQRS
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PQRSId == id);
            if (pQRS == null)
            {
                return NotFound();
            }

            return View(pQRS);
        }

        // GET: PQRS/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido");
            return View();
        }

        // POST: PQRS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PQRSId,Descripcion,ClienteId")] PQRS pQRS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pQRS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", pQRS.ClienteId);
            return View(pQRS);
        }

        // GET: PQRS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PQRS == null)
            {
                return NotFound();
            }

            var pQRS = await _context.PQRS.FindAsync(id);
            if (pQRS == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", pQRS.ClienteId);
            return View(pQRS);
        }

        // POST: PQRS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PQRSId,Descripcion,ClienteId")] PQRS pQRS)
        {
            if (id != pQRS.PQRSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pQRS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PQRSExists(pQRS.PQRSId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", pQRS.ClienteId);
            return View(pQRS);
        }

        // GET: PQRS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PQRS == null)
            {
                return NotFound();
            }

            var pQRS = await _context.PQRS
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PQRSId == id);
            if (pQRS == null)
            {
                return NotFound();
            }

            return View(pQRS);
        }

        // POST: PQRS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PQRS == null)
            {
                return Problem("Entity set 'DataContext.PQRS'  is null.");
            }
            var pQRS = await _context.PQRS.FindAsync(id);
            if (pQRS != null)
            {
                _context.PQRS.Remove(pQRS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PQRSExists(int id)
        {
          return (_context.PQRS?.Any(e => e.PQRSId == id)).GetValueOrDefault();
        }
    }
}
