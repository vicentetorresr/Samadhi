using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SamadhiEstesi.Data;
using SamadhiEstesi.Modelos;

namespace SamadhiEstesi.Controllers
{
    public class SuscripcionesController : Controller
    {
        private readonly sistema_gestion_completoContext _context;

        public SuscripcionesController(sistema_gestion_completoContext context)
        {
            _context = context;
        }

        // GET: Suscripciones
        public async Task<IActionResult> Index()
        {
              return _context.Suscripciones != null ? 
                          View(await _context.Suscripciones.ToListAsync()) :
                          Problem("Entity set 'sistema_gestion_completoContext.Suscripciones'  is null.");
        }

        // GET: Suscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Suscripciones == null)
            {
                return NotFound();
            }

            var suscripcione = await _context.Suscripciones
                .FirstOrDefaultAsync(m => m.IdSuscripcion == id);
            if (suscripcione == null)
            {
                return NotFound();
            }

            return View(suscripcione);
        }

        // GET: Suscripciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuscripcion,Descripcion,Periodicidad,Valor,Estado")] Suscripcione suscripcione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suscripcione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suscripcione);
        }

        // GET: Suscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Suscripciones == null)
            {
                return NotFound();
            }

            var suscripcione = await _context.Suscripciones.FindAsync(id);
            if (suscripcione == null)
            {
                return NotFound();
            }
            return View(suscripcione);
        }

        // POST: Suscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSuscripcion,Descripcion,Periodicidad,Valor,Estado")] Suscripcione suscripcione)
        {
            if (id != suscripcione.IdSuscripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suscripcione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuscripcioneExists(suscripcione.IdSuscripcion))
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
            return View(suscripcione);
        }

        // GET: Suscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Suscripciones == null)
            {
                return NotFound();
            }

            var suscripcione = await _context.Suscripciones
                .FirstOrDefaultAsync(m => m.IdSuscripcion == id);
            if (suscripcione == null)
            {
                return NotFound();
            }

            return View(suscripcione);
        }

        // POST: Suscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Suscripciones == null)
            {
                return Problem("Entity set 'sistema_gestion_completoContext.Suscripciones'  is null.");
            }
            var suscripcione = await _context.Suscripciones.FindAsync(id);
            if (suscripcione != null)
            {
                _context.Suscripciones.Remove(suscripcione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuscripcioneExists(int id)
        {
          return (_context.Suscripciones?.Any(e => e.IdSuscripcion == id)).GetValueOrDefault();
        }
    }
}
