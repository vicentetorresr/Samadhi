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
    public class AntecedentesMedicoesController : Controller
    {
        private readonly sistema_gestion_completoContext _context;

        public AntecedentesMedicoesController(sistema_gestion_completoContext context)
        {
            _context = context;
        }

        // GET: AntecedentesMedicoes
        public async Task<IActionResult> Index()
        {
            var sistema_gestion_completoContext = _context.AntecedentesMedicos.Include(a => a.IdPersonaNavigation);
            return View(await sistema_gestion_completoContext.ToListAsync());
        }

        // GET: AntecedentesMedicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AntecedentesMedicos == null)
            {
                return NotFound();
            }

            var antecedentesMedico = await _context.AntecedentesMedicos
                .Include(a => a.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdAntecedente == id);
            if (antecedentesMedico == null)
            {
                return NotFound();
            }

            return View(antecedentesMedico);
        }

        // GET: AntecedentesMedicoes/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: AntecedentesMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAntecedente,IdPersona,Tipo,Descripcion,FechaRegistro")] AntecedentesMedico antecedentesMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antecedentesMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", antecedentesMedico.IdPersona);
            return View(antecedentesMedico);
        }

        // GET: AntecedentesMedicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AntecedentesMedicos == null)
            {
                return NotFound();
            }

            var antecedentesMedico = await _context.AntecedentesMedicos.FindAsync(id);
            if (antecedentesMedico == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", antecedentesMedico.IdPersona);
            return View(antecedentesMedico);
        }

        // POST: AntecedentesMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAntecedente,IdPersona,Tipo,Descripcion,FechaRegistro")] AntecedentesMedico antecedentesMedico)
        {
            if (id != antecedentesMedico.IdAntecedente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antecedentesMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntecedentesMedicoExists(antecedentesMedico.IdAntecedente))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", antecedentesMedico.IdPersona);
            return View(antecedentesMedico);
        }

        // GET: AntecedentesMedicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AntecedentesMedicos == null)
            {
                return NotFound();
            }

            var antecedentesMedico = await _context.AntecedentesMedicos
                .Include(a => a.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdAntecedente == id);
            if (antecedentesMedico == null)
            {
                return NotFound();
            }

            return View(antecedentesMedico);
        }

        // POST: AntecedentesMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AntecedentesMedicos == null)
            {
                return Problem("Entity set 'sistema_gestion_completoContext.AntecedentesMedicos'  is null.");
            }
            var antecedentesMedico = await _context.AntecedentesMedicos.FindAsync(id);
            if (antecedentesMedico != null)
            {
                _context.AntecedentesMedicos.Remove(antecedentesMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntecedentesMedicoExists(int id)
        {
          return (_context.AntecedentesMedicos?.Any(e => e.IdAntecedente == id)).GetValueOrDefault();
        }
    }
}
