using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLINICA_CRUD.Data;
using CLINICA_CRUD.Models;

namespace CLINICA_CRUD.Controllers
{
    public class RegistroMedicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroMedicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroMedicoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroMedico.Include(r => r.Citas).Include(r => r.IdAlergiaNavigation).Include(r => r.IdDiscapacidadNavigation).Include(r => r.IdEnfermedadNavigation).Include(r => r.IdPacienteNavigation).Include(r => r.IdTratamientoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroMedicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroMedico == null)
            {
                return NotFound();
            }

            var registroMedico = await _context.RegistroMedico
                .Include(r => r.Citas)
                .Include(r => r.IdAlergiaNavigation)
                .Include(r => r.IdDiscapacidadNavigation)
                .Include(r => r.IdEnfermedadNavigation)
                .Include(r => r.IdPacienteNavigation)
                .Include(r => r.IdTratamientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroMedico == null)
            {
                return NotFound();
            }

            return View(registroMedico);
        }

        // GET: RegistroMedicoes/Create
        public IActionResult Create()
        {
            ViewData["CitasId"] = new SelectList(_context.Cita, "Id", "Id");
            ViewData["IdAlergiaNavigationId"] = new SelectList(_context.Set<Alergium>(), "Id", "Id");
            ViewData["IdDiscapacidadNavigationId"] = new SelectList(_context.Set<Discapacidad>(), "Id", "Id");
            ViewData["IdEnfermedadNavigationId"] = new SelectList(_context.Set<Enfermedad>(), "Id", "Id");
            ViewData["IdPacienteNavigationId"] = new SelectList(_context.Paciente, "Id", "Id");
            ViewData["IdTratamientoNavigationId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Id");
            return View();
        }

        // POST: RegistroMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPaciente,IdDiscapacidad,IdAlergia,IdEnfermedad,IdTratamiento,IdAlergiaNavigationId,IdDiscapacidadNavigationId,IdEnfermedadNavigationId,IdPacienteNavigationId,IdTratamientoNavigationId,CitasId")] RegistroMedico registroMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitasId"] = new SelectList(_context.Cita, "Id", "Id", registroMedico.CitasId);
            ViewData["IdAlergiaNavigationId"] = new SelectList(_context.Set<Alergium>(), "Id", "Id", registroMedico.IdAlergiaNavigationId);
            ViewData["IdDiscapacidadNavigationId"] = new SelectList(_context.Set<Discapacidad>(), "Id", "Id", registroMedico.IdDiscapacidadNavigationId);
            ViewData["IdEnfermedadNavigationId"] = new SelectList(_context.Set<Enfermedad>(), "Id", "Id", registroMedico.IdEnfermedadNavigationId);
            ViewData["IdPacienteNavigationId"] = new SelectList(_context.Paciente, "Id", "Id", registroMedico.IdPacienteNavigationId);
            ViewData["IdTratamientoNavigationId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Id", registroMedico.IdTratamientoNavigationId);
            return View(registroMedico);
        }

        // GET: RegistroMedicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroMedico == null)
            {
                return NotFound();
            }

            var registroMedico = await _context.RegistroMedico.FindAsync(id);
            if (registroMedico == null)
            {
                return NotFound();
            }
            ViewData["CitasId"] = new SelectList(_context.Cita, "Id", "Id", registroMedico.CitasId);
            ViewData["IdAlergiaNavigationId"] = new SelectList(_context.Set<Alergium>(), "Id", "Id", registroMedico.IdAlergiaNavigationId);
            ViewData["IdDiscapacidadNavigationId"] = new SelectList(_context.Set<Discapacidad>(), "Id", "Id", registroMedico.IdDiscapacidadNavigationId);
            ViewData["IdEnfermedadNavigationId"] = new SelectList(_context.Set<Enfermedad>(), "Id", "Id", registroMedico.IdEnfermedadNavigationId);
            ViewData["IdPacienteNavigationId"] = new SelectList(_context.Paciente, "Id", "Id", registroMedico.IdPacienteNavigationId);
            ViewData["IdTratamientoNavigationId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Id", registroMedico.IdTratamientoNavigationId);
            return View(registroMedico);
        }

        // POST: RegistroMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPaciente,IdDiscapacidad,IdAlergia,IdEnfermedad,IdTratamiento,IdAlergiaNavigationId,IdDiscapacidadNavigationId,IdEnfermedadNavigationId,IdPacienteNavigationId,IdTratamientoNavigationId,CitasId")] RegistroMedico registroMedico)
        {
            if (id != registroMedico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroMedicoExists(registroMedico.Id))
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
            ViewData["CitasId"] = new SelectList(_context.Cita, "Id", "Id", registroMedico.CitasId);
            ViewData["IdAlergiaNavigationId"] = new SelectList(_context.Set<Alergium>(), "Id", "Id", registroMedico.IdAlergiaNavigationId);
            ViewData["IdDiscapacidadNavigationId"] = new SelectList(_context.Set<Discapacidad>(), "Id", "Id", registroMedico.IdDiscapacidadNavigationId);
            ViewData["IdEnfermedadNavigationId"] = new SelectList(_context.Set<Enfermedad>(), "Id", "Id", registroMedico.IdEnfermedadNavigationId);
            ViewData["IdPacienteNavigationId"] = new SelectList(_context.Paciente, "Id", "Id", registroMedico.IdPacienteNavigationId);
            ViewData["IdTratamientoNavigationId"] = new SelectList(_context.Set<Tratamiento>(), "Id", "Id", registroMedico.IdTratamientoNavigationId);
            return View(registroMedico);
        }

        // GET: RegistroMedicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroMedico == null)
            {
                return NotFound();
            }

            var registroMedico = await _context.RegistroMedico
                .Include(r => r.Citas)
                .Include(r => r.IdAlergiaNavigation)
                .Include(r => r.IdDiscapacidadNavigation)
                .Include(r => r.IdEnfermedadNavigation)
                .Include(r => r.IdPacienteNavigation)
                .Include(r => r.IdTratamientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroMedico == null)
            {
                return NotFound();
            }

            return View(registroMedico);
        }

        // POST: RegistroMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroMedico == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegistroMedico'  is null.");
            }
            var registroMedico = await _context.RegistroMedico.FindAsync(id);
            if (registroMedico != null)
            {
                _context.RegistroMedico.Remove(registroMedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroMedicoExists(int id)
        {
          return (_context.RegistroMedico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
