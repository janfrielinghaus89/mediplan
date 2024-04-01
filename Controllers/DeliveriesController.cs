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
    public class DeliveriesController : Controller
    {
        private readonly AppDbContext _context;

        public DeliveriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Deliveries
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Deliveries.Include(d => d.Inventory).Include(d => d.Medication).Include(d => d.Patient);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .Include(d => d.Inventory)
                .Include(d => d.Medication)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "InventoryId", "InventoryId");
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName");
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryId,DeliveryDate,Quantity,PatientId,MedicationId,InventoryId")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "InventoryId", "InventoryId", delivery.InventoryId);
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", delivery.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName", delivery.PatientId);
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "InventoryId", "InventoryId", delivery.InventoryId);
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", delivery.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName", delivery.PatientId);
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryId,DeliveryDate,Quantity,PatientId,MedicationId,InventoryId")] Delivery delivery)
        {
            if (id != delivery.DeliveryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryExists(delivery.DeliveryId))
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
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "InventoryId", "InventoryId", delivery.InventoryId);
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", delivery.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FirstName", delivery.PatientId);
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .Include(d => d.Inventory)
                .Include(d => d.Medication)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryExists(int id)
        {
            return _context.Deliveries.Any(e => e.DeliveryId == id);
        }
    }
}
