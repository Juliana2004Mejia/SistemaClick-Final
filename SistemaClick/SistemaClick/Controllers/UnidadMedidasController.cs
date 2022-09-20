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
    public class UnidadMedidasController : Controller
    {
        private readonly DataContext _context;

        public UnidadMedidasController(DataContext context)
        {
            _context = context;
        }

        // GET: UnidadMedidas
        public async Task<IActionResult> Index()
        {
              return _context.UnidadMedidas != null ? 
                          View(await _context.UnidadMedidas.ToListAsync()) :
                          Problem("Entity set 'DataContext.UnidadMedidas'  is null.");
        }

        // GET: UnidadMedidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnidadMedidas == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedidas
                .FirstOrDefaultAsync(m => m.UnidadMedidaId == id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            return View(unidadMedida);
        }

        // GET: UnidadMedidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadMedidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidadMedidaId,Nombre")] UnidadMedida unidadMedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadMedida);
        }

        // GET: UnidadMedidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnidadMedidas == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedidas.FindAsync(id);
            if (unidadMedida == null)
            {
                return NotFound();
            }
            return View(unidadMedida);
        }

        // POST: UnidadMedidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnidadMedidaId,Nombre")] UnidadMedida unidadMedida)
        {
            if (id != unidadMedida.UnidadMedidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadMedidaExists(unidadMedida.UnidadMedidaId))
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
            return View(unidadMedida);
        }

        // GET: UnidadMedidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnidadMedidas == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedidas
                .FirstOrDefaultAsync(m => m.UnidadMedidaId == id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            return View(unidadMedida);
        }

        // POST: UnidadMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnidadMedidas == null)
            {
                return Problem("Entity set 'DataContext.UnidadMedidas'  is null.");
            }
            var unidadMedida = await _context.UnidadMedidas.FindAsync(id);
            if (unidadMedida != null)
            {
                _context.UnidadMedidas.Remove(unidadMedida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadMedidaExists(int id)
        {
          return (_context.UnidadMedidas?.Any(e => e.UnidadMedidaId == id)).GetValueOrDefault();
        }
    }
}
