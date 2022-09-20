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
    public class ProductosController : Controller
    {
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Productos.Include(p => p.Categoria).Include(p => p.Inventario).Include(p => p.Proveedor).Include(p => p.UnidadMedida);
            return View(await dataContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Inventario)
                .Include(p => p.Proveedor)
                .Include(p => p.UnidadMedida)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nombre");
            ViewData["InventarioId"] = new SelectList(_context.Inventarios, "InventarioId", "InventarioId");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Apellido");
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "UnidadMedidaId", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Nombre,Marca,Precio_unidad,Descripcion,NombreProveedor,CategoriaId,UnidadMedidaId,InventarioId,ProveedorId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nombre", producto.CategoriaId);
            ViewData["InventarioId"] = new SelectList(_context.Inventarios, "InventarioId", "InventarioId", producto.InventarioId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Apellido", producto.ProveedorId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "UnidadMedidaId", "Nombre", producto.UnidadMedidaId);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nombre", producto.CategoriaId);
            ViewData["InventarioId"] = new SelectList(_context.Inventarios, "InventarioId", "InventarioId", producto.InventarioId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Apellido", producto.ProveedorId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "UnidadMedidaId", "Nombre", producto.UnidadMedidaId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Nombre,Marca,Precio_unidad,Descripcion,NombreProveedor,CategoriaId,UnidadMedidaId,InventarioId,ProveedorId")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nombre", producto.CategoriaId);
            ViewData["InventarioId"] = new SelectList(_context.Inventarios, "InventarioId", "InventarioId", producto.InventarioId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Apellido", producto.ProveedorId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "UnidadMedidaId", "Nombre", producto.UnidadMedidaId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Inventario)
                .Include(p => p.Proveedor)
                .Include(p => p.UnidadMedida)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'DataContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.ProductoId == id)).GetValueOrDefault();
        }
    }
}
