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
    public class RecoleccionesController : Controller
    {
        private readonly DataContext _context;

        public RecoleccionesController(DataContext context)
        {
            _context = context;
        }

        // GET: Recolecciones
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Recolecciones.Include(r => r.Empleado).Include(r => r.Localidad);
            return View(await dataContext.ToListAsync());
        }

        // GET: Recolecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recolecciones == null)
            {
                return NotFound();
            }

            var recoleccion = await _context.Recolecciones
                .Include(r => r.Empleado)
                .Include(r => r.Localidad)
                .FirstOrDefaultAsync(m => m.RecoleccionId == id);
            if (recoleccion == null)
            {
                return NotFound();
            }

            return View(recoleccion);
        }

        // GET: Recolecciones/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido");
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre");
            return View();
        }

        // POST: Recolecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecoleccionId,Fecha,Direccion_cliente,Objetivo,Nombre_cliente,Hora_llegada,EmpleadoId,LocalidadId")] Recoleccion recoleccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recoleccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido", recoleccion.EmpleadoId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre", recoleccion.LocalidadId);
            return View(recoleccion);
        }

        // GET: Recolecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recolecciones == null)
            {
                return NotFound();
            }

            var recoleccion = await _context.Recolecciones.FindAsync(id);
            if (recoleccion == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido", recoleccion.EmpleadoId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre", recoleccion.LocalidadId);
            return View(recoleccion);
        }

        // POST: Recolecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecoleccionId,Fecha,Direccion_cliente,Objetivo,Nombre_cliente,Hora_llegada,EmpleadoId,LocalidadId")] Recoleccion recoleccion)
        {
            if (id != recoleccion.RecoleccionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recoleccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecoleccionExists(recoleccion.RecoleccionId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido", recoleccion.EmpleadoId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre", recoleccion.LocalidadId);
            return View(recoleccion);
        }

        // GET: Recolecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recolecciones == null)
            {
                return NotFound();
            }

            var recoleccion = await _context.Recolecciones
                .Include(r => r.Empleado)
                .Include(r => r.Localidad)
                .FirstOrDefaultAsync(m => m.RecoleccionId == id);
            if (recoleccion == null)
            {
                return NotFound();
            }

            return View(recoleccion);
        }

        // POST: Recolecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recolecciones == null)
            {
                return Problem("Entity set 'DataContext.Recolecciones'  is null.");
            }
            var recoleccion = await _context.Recolecciones.FindAsync(id);
            if (recoleccion != null)
            {
                _context.Recolecciones.Remove(recoleccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecoleccionExists(int id)
        {
          return (_context.Recolecciones?.Any(e => e.RecoleccionId == id)).GetValueOrDefault();
        }
    }
}
