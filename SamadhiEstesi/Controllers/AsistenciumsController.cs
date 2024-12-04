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
    public class AsistenciumsController : Controller
    {
        private readonly sistema_gestion_completoContext _context;

        public AsistenciumsController(sistema_gestion_completoContext context)
        {
            _context = context;
        }

        // GET: Asistenciums
        public async Task<IActionResult> Index()
        {
            var sistema_gestion_completoContext = _context.Asistencia.Include(a => a.IdPersonaNavigation);
            return View(await sistema_gestion_completoContext.ToListAsync());
        }

        // GET: Asistenciums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia
                .Include(a => a.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdAsistencia == id);
            if (asistencium == null)
            {
                return NotFound();
            }

            return View(asistencium);
        }

        // GET: Asistenciums/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: Asistenciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsistencia,IdPersona,FechaAsistencia,Observacion")] Asistencium asistencium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", asistencium.IdPersona);
            return View(asistencium);
        }

        // GET: Asistenciums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia.FindAsync(id);
            if (asistencium == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", asistencium.IdPersona);
            return View(asistencium);
        }

        // POST: Asistenciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsistencia,IdPersona,FechaAsistencia,Observacion")] Asistencium asistencium)
        {
            if (id != asistencium.IdAsistencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciumExists(asistencium.IdAsistencia))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", asistencium.IdPersona);
            return View(asistencium);
        }

        // GET: Asistenciums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia
                .Include(a => a.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdAsistencia == id);
            if (asistencium == null)
            {
                return NotFound();
            }

            return View(asistencium);
        }

        // POST: Asistenciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asistencia == null)
            {
                return Problem("Entity set 'sistema_gestion_completoContext.Asistencia'  is null.");
            }
            var asistencium = await _context.Asistencia.FindAsync(id);
            if (asistencium != null)
            {
                _context.Asistencia.Remove(asistencium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciumExists(int id)
        {
          return (_context.Asistencia?.Any(e => e.IdAsistencia == id)).GetValueOrDefault();
        }
    }
}
