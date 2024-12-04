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
    public class RutinasController : Controller
    {
        private readonly sistema_gestion_completoContext _context;

        public RutinasController(sistema_gestion_completoContext context)
        {
            _context = context;
        }

        // GET: Rutinas
        public async Task<IActionResult> Index()
        {
            var sistema_gestion_completoContext = _context.Rutinas.Include(r => r.IdPersonaNavigation);
            return View(await sistema_gestion_completoContext.ToListAsync());
        }

        // GET: Rutinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rutinas == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .Include(r => r.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdRutina == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // GET: Rutinas/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: Rutinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRutina,IdPersona,Descripción,Fecha,Comentario,Estado")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", rutina.IdPersona);
            return View(rutina);
        }

        // GET: Rutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rutinas == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", rutina.IdPersona);
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRutina,IdPersona,Descripción,Fecha,Comentario,Estado")] Rutina rutina)
        {
            if (id != rutina.IdRutina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutinaExists(rutina.IdRutina))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", rutina.IdPersona);
            return View(rutina);
        }

        // GET: Rutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rutinas == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .Include(r => r.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdRutina == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // POST: Rutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rutinas == null)
            {
                return Problem("Entity set 'sistema_gestion_completoContext.Rutinas'  is null.");
            }
            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina != null)
            {
                _context.Rutinas.Remove(rutina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutinaExists(int id)
        {
          return (_context.Rutinas?.Any(e => e.IdRutina == id)).GetValueOrDefault();
        }
    }
}
