using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class SubProductoController : Controller
    {
        private readonly Db_RespaldoContext _context;

        public SubProductoController(Db_RespaldoContext context)
        {
            _context = context;
        }

        // GET: SubProducto
        public async Task<IActionResult> Index()
        {
            var db_RespaldoContext = _context.SubProductos.Include(s => s.IdProductoNavigation);
            return View(await db_RespaldoContext.ToListAsync());
        }

        // GET: SubProducto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubProductos == null)
            {
                return NotFound();
            }

            var subProducto = await _context.SubProductos
                .Include(s => s.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdSubProducto == id);
            if (subProducto == null)
            {
                return NotFound();
            }

            return View(subProducto);
        }

        // GET: SubProducto/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: SubProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubProducto,IdStock,IdProducto,NombreSubProducto,DescripcionSubProducto")] SubProducto subProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", subProducto.IdProducto);
            return View(subProducto);
        }

        // GET: SubProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubProductos == null)
            {
                return NotFound();
            }

            var subProducto = await _context.SubProductos.FindAsync(id);
            if (subProducto == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", subProducto.IdProducto);
            return View(subProducto);
        }

        // POST: SubProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubProducto,IdStock,IdProducto,NombreSubProducto,DescripcionSubProducto")] SubProducto subProducto)
        {
            if (id != subProducto.IdSubProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubProductoExists(subProducto.IdSubProducto))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", subProducto.IdProducto);
            return View(subProducto);
        }

        // GET: SubProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubProductos == null)
            {
                return NotFound();
            }

            var subProducto = await _context.SubProductos
                .Include(s => s.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdSubProducto == id);
            if (subProducto == null)
            {
                return NotFound();
            }

            return View(subProducto);
        }

        // POST: SubProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubProductos == null)
            {
                return Problem("Entity set 'Db_RespaldoContext.SubProductos'  is null.");
            }
            var subProducto = await _context.SubProductos.FindAsync(id);
            if (subProducto != null)
            {
                _context.SubProductos.Remove(subProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubProductoExists(int id)
        {
          return _context.SubProductos.Any(e => e.IdSubProducto == id);
        }
    }
}
