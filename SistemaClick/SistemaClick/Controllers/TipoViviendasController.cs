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
    public class TipoViviendasController : Controller
    {
        private readonly DataContext _context;

        public TipoViviendasController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoViviendas
        public async Task<IActionResult> Index()
        {
              return _context.TipoViviendas != null ? 
                          View(await _context.TipoViviendas.ToListAsync()) :
                          Problem("Entity set 'DataContext.TipoViviendas'  is null.");
        }

        // GET: TipoViviendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoViviendas == null)
            {
                return NotFound();
            }

            var tipoVivienda = await _context.TipoViviendas
                .FirstOrDefaultAsync(m => m.TipoViviendaId == id);
            if (tipoVivienda == null)
            {
                return NotFound();
            }

            return View(tipoVivienda);
        }

        // GET: TipoViviendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoViviendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoViviendaId,Nombre")] TipoVivienda tipoVivienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoVivienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoVivienda);
        }

        // GET: TipoViviendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoViviendas == null)
            {
                return NotFound();
            }

            var tipoVivienda = await _context.TipoViviendas.FindAsync(id);
            if (tipoVivienda == null)
            {
                return NotFound();
            }
            return View(tipoVivienda);
        }

        // POST: TipoViviendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoViviendaId,Nombre")] TipoVivienda tipoVivienda)
        {
            if (id != tipoVivienda.TipoViviendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoVivienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoViviendaExists(tipoVivienda.TipoViviendaId))
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
            return View(tipoVivienda);
        }

        // GET: TipoViviendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoViviendas == null)
            {
                return NotFound();
            }

            var tipoVivienda = await _context.TipoViviendas
                .FirstOrDefaultAsync(m => m.TipoViviendaId == id);
            if (tipoVivienda == null)
            {
                return NotFound();
            }

            return View(tipoVivienda);
        }

        // POST: TipoViviendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoViviendas == null)
            {
                return Problem("Entity set 'DataContext.TipoViviendas'  is null.");
            }
            var tipoVivienda = await _context.TipoViviendas.FindAsync(id);
            if (tipoVivienda != null)
            {
                _context.TipoViviendas.Remove(tipoVivienda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoViviendaExists(int id)
        {
          return (_context.TipoViviendas?.Any(e => e.TipoViviendaId == id)).GetValueOrDefault();
        }
    }
}
