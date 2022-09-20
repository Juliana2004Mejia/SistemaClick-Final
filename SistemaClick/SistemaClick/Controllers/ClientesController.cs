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
    public class ClientesController : Controller
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Clientes.Include(c => c.Beneficio).Include(c => c.Localidad).Include(c => c.Plan).Include(c => c.TipoDocumento).Include(c => c.TipoVivienda);
            return View(await dataContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Beneficio)
                .Include(c => c.Localidad)
                .Include(c => c.Plan)
                .Include(c => c.TipoDocumento)
                .Include(c => c.TipoVivienda)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["BeneficioId"] = new SelectList(_context.Beneficios, "BeneficioId", "Nombre");
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre");
            ViewData["PlanId"] = new SelectList(_context.Planes, "PlanId", "Nombre");
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre");
            ViewData["TipoViviendaId"] = new SelectList(_context.TipoViviendas, "TipoViviendaId", "Nombre");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Usuario,Nombre,Fecha_Recoleccion,Apellido,Numero_documento,Direccion,Email,Telefono,Fecha_Inscripcion,TipoDocumentoId,TipoViviendaId,LocalidadId,PlanId,BeneficioId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeneficioId"] = new SelectList(_context.Beneficios, "BeneficioId", "Nombre", cliente.BeneficioId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre", cliente.LocalidadId);
            ViewData["PlanId"] = new SelectList(_context.Planes, "PlanId", "Nombre", cliente.PlanId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre", cliente.TipoDocumentoId);
            ViewData["TipoViviendaId"] = new SelectList(_context.TipoViviendas, "TipoViviendaId", "Nombre", cliente.TipoViviendaId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["BeneficioId"] = new SelectList(_context.Beneficios, "BeneficioId", "Nombre", cliente.BeneficioId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre", cliente.LocalidadId);
            ViewData["PlanId"] = new SelectList(_context.Planes, "PlanId", "Nombre", cliente.PlanId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre", cliente.TipoDocumentoId);
            ViewData["TipoViviendaId"] = new SelectList(_context.TipoViviendas, "TipoViviendaId", "Nombre", cliente.TipoViviendaId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Usuario,Nombre,Fecha_Recoleccion,Apellido,Numero_documento,Direccion,Email,Telefono,Fecha_Inscripcion,TipoDocumentoId,TipoViviendaId,LocalidadId,PlanId,BeneficioId")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            ViewData["BeneficioId"] = new SelectList(_context.Beneficios, "BeneficioId", "Nombre", cliente.BeneficioId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "LocalidadId", "Nombre", cliente.LocalidadId);
            ViewData["PlanId"] = new SelectList(_context.Planes, "PlanId", "Nombre", cliente.PlanId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre", cliente.TipoDocumentoId);
            ViewData["TipoViviendaId"] = new SelectList(_context.TipoViviendas, "TipoViviendaId", "Nombre", cliente.TipoViviendaId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Beneficio)
                .Include(c => c.Localidad)
                .Include(c => c.Plan)
                .Include(c => c.TipoDocumento)
                .Include(c => c.TipoVivienda)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'DataContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }
    }
}
