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
    public class RegistrosHistoricoesController : Controller
    {
        private readonly sistema_gestion_completoContext _context;

        public RegistrosHistoricoesController(sistema_gestion_completoContext context)
        {
            _context = context;
        }

        // GET: RegistrosHistoricoes
        public async Task<IActionResult> Index()
        {
            var sistema_gestion_completoContext = _context.RegistrosHistoricos.Include(r => r.IdPersonaNavigation);
            return View(await sistema_gestion_completoContext.ToListAsync());
        }

        // GET: RegistrosHistoricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistrosHistoricos == null)
            {
                return NotFound();
            }

            var registrosHistorico = await _context.RegistrosHistoricos
                .Include(r => r.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registrosHistorico == null)
            {
                return NotFound();
            }

            return View(registrosHistorico);
        }

        // GET: RegistrosHistoricoes/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: RegistrosHistoricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistro,IdPersona,Accion,Fecha")] RegistrosHistorico registrosHistorico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrosHistorico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", registrosHistorico.IdPersona);
            return View(registrosHistorico);
        }

        // GET: RegistrosHistoricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistrosHistoricos == null)
            {
                return NotFound();
            }

            var registrosHistorico = await _context.RegistrosHistoricos.FindAsync(id);
            if (registrosHistorico == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", registrosHistorico.IdPersona);
            return View(registrosHistorico);
        }

        // POST: RegistrosHistoricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistro,IdPersona,Accion,Fecha")] RegistrosHistorico registrosHistorico)
        {
            if (id != registrosHistorico.IdRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrosHistorico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrosHistoricoExists(registrosHistorico.IdRegistro))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", registrosHistorico.IdPersona);
            return View(registrosHistorico);
        }

        // GET: RegistrosHistoricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistrosHistoricos == null)
            {
                return NotFound();
            }

            var registrosHistorico = await _context.RegistrosHistoricos
                .Include(r => r.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registrosHistorico == null)
            {
                return NotFound();
            }

            return View(registrosHistorico);
        }

        // POST: RegistrosHistoricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistrosHistoricos == null)
            {
                return Problem("Entity set 'sistema_gestion_completoContext.RegistrosHistoricos'  is null.");
            }
            var registrosHistorico = await _context.RegistrosHistoricos.FindAsync(id);
            if (registrosHistorico != null)
            {
                _context.RegistrosHistoricos.Remove(registrosHistorico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrosHistoricoExists(int id)
        {
          return (_context.RegistrosHistoricos?.Any(e => e.IdRegistro == id)).GetValueOrDefault();
        }
    }
}
