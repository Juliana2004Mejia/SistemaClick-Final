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
    public class EmpleadosController : Controller
    {
        private readonly DataContext _context;

        public EmpleadosController(DataContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Empleados.Include(e => e.AFP).Include(e => e.ARL).Include(e => e.CCF).Include(e => e.Cargo).Include(e => e.EPS).Include(e => e.Rol).Include(e => e.TipoContrato).Include(e => e.TipoDocumento);
            return View(await dataContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.AFP)
                .Include(e => e.ARL)
                .Include(e => e.CCF)
                .Include(e => e.Cargo)
                .Include(e => e.EPS)
                .Include(e => e.Rol)
                .Include(e => e.TipoContrato)
                .Include(e => e.TipoDocumento)
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["AFPId"] = new SelectList(_context.AFP, "AFPId", "Nombre");
            ViewData["ARLId"] = new SelectList(_context.ARL, "ARLId", "Nombre");
            ViewData["CCFId"] = new SelectList(_context.CCF, "CCFId", "Nombre");
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "Nombre");
            ViewData["EPSId"] = new SelectList(_context.EPS, "EPSId", "Nombre");
            ViewData["RolId"] = new SelectList(_context.Roles, "RolId", "Nombre");
            ViewData["TipoContratoId"] = new SelectList(_context.TipoContratos, "TipoContratoId", "Nombre");
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,Email,Nombre,Apellido,Numero_documento,Telefono,Direccion,Salario,CargoId,TipoContratoId,RolId,TipoDocumentoId,EPSId,ARLId,CCFId,AFPId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AFPId"] = new SelectList(_context.AFP, "AFPId", "Nombre", empleado.AFPId);
            ViewData["ARLId"] = new SelectList(_context.ARL, "ARLId", "Nombre", empleado.ARLId);
            ViewData["CCFId"] = new SelectList(_context.CCF, "CCFId", "Nombre", empleado.CCFId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "Nombre", empleado.CargoId);
            ViewData["EPSId"] = new SelectList(_context.EPS, "EPSId", "Nombre", empleado.EPSId);
            ViewData["RolId"] = new SelectList(_context.Roles, "RolId", "Nombre", empleado.RolId);
            ViewData["TipoContratoId"] = new SelectList(_context.TipoContratos, "TipoContratoId", "Nombre", empleado.TipoContratoId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre", empleado.TipoDocumentoId);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["AFPId"] = new SelectList(_context.AFP, "AFPId", "Nombre", empleado.AFPId);
            ViewData["ARLId"] = new SelectList(_context.ARL, "ARLId", "Nombre", empleado.ARLId);
            ViewData["CCFId"] = new SelectList(_context.CCF, "CCFId", "Nombre", empleado.CCFId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "Nombre", empleado.CargoId);
            ViewData["EPSId"] = new SelectList(_context.EPS, "EPSId", "Nombre", empleado.EPSId);
            ViewData["RolId"] = new SelectList(_context.Roles, "RolId", "Nombre", empleado.RolId);
            ViewData["TipoContratoId"] = new SelectList(_context.TipoContratos, "TipoContratoId", "Nombre", empleado.TipoContratoId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre", empleado.TipoDocumentoId);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoId,Email,Nombre,Apellido,Numero_documento,Telefono,Direccion,Salario,CargoId,TipoContratoId,RolId,TipoDocumentoId,EPSId,ARLId,CCFId,AFPId")] Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.EmpleadoId))
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
            ViewData["AFPId"] = new SelectList(_context.AFP, "AFPId", "Nombre", empleado.AFPId);
            ViewData["ARLId"] = new SelectList(_context.ARL, "ARLId", "Nombre", empleado.ARLId);
            ViewData["CCFId"] = new SelectList(_context.CCF, "CCFId", "Nombre", empleado.CCFId);
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "Nombre", empleado.CargoId);
            ViewData["EPSId"] = new SelectList(_context.EPS, "EPSId", "Nombre", empleado.EPSId);
            ViewData["RolId"] = new SelectList(_context.Roles, "RolId", "Nombre", empleado.RolId);
            ViewData["TipoContratoId"] = new SelectList(_context.TipoContratos, "TipoContratoId", "Nombre", empleado.TipoContratoId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "TipoDocumentoId", "Nombre", empleado.TipoDocumentoId);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.AFP)
                .Include(e => e.ARL)
                .Include(e => e.CCF)
                .Include(e => e.Cargo)
                .Include(e => e.EPS)
                .Include(e => e.Rol)
                .Include(e => e.TipoContrato)
                .Include(e => e.TipoDocumento)
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'DataContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleados?.Any(e => e.EmpleadoId == id)).GetValueOrDefault();
        }
    }
}
