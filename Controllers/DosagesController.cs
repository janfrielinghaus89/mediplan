using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MEDIplan.Models;

namespace MEDIplan.Controllers
{
    public class DosagesController : Controller
    {
        private readonly AppDbContext _context;

        public DosagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dosages
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Dosages.Include(d => d.Medication).Include(d => d.Patient);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Dosages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosage = await _context.Dosages
                .Include(d => d.Medication)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DosageId == id);
            if (dosage == null)
            {
                return NotFound();
            }

            return View(dosage);
        }

        // GET: Dosages/Create
        public IActionResult Create()
        {
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName");
            return View();
        }

        // POST: Dosages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosageId,DosageAmount,DosageInstruction,MedicationId,PatientId")] Dosage dosage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", dosage.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName", dosage.PatientId);
            return View(dosage);
        }

        // GET: Dosages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosage = await _context.Dosages.FindAsync(id);
            if (dosage == null)
            {
                return NotFound();
            }
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", dosage.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName", dosage.PatientId);
            return View(dosage);
        }

        // POST: Dosages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosageId,DosageAmount,DosageInstruction,MedicationId,PatientId")] Dosage dosage)
        {
            if (id != dosage.DosageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosageExists(dosage.DosageId))
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
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", dosage.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName", dosage.PatientId);
            return View(dosage);
        }

        // GET: Dosages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosage = await _context.Dosages
                .Include(d => d.Medication)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DosageId == id);
            if (dosage == null)
            {
                return NotFound();
            }

            return View(dosage);
        }

        // POST: Dosages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosage = await _context.Dosages.FindAsync(id);
            if (dosage != null)
            {
                _context.Dosages.Remove(dosage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosageExists(int id)
        {
            return _context.Dosages.Any(e => e.DosageId == id);
        }
    }
}
