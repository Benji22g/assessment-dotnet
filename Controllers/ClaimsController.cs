using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetC_Assessment___Coding_exercise.Models;

namespace NetC_Assessment___Coding_exercise.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly benjaminGarridoDatabaseContext _context;

        public ClaimsController(benjaminGarridoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Claims
        public async Task<IActionResult> Index()
        {
            var benjaminGarridoDatabaseContext = _context.Claims.Include(c => c.Vehicle);
            return View(await benjaminGarridoDatabaseContext.ToListAsync());
        }

        // GET: Claims/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Claims == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.Vehicle)
                .FirstOrDefaultAsync(m => m.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // GET: Claims/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclesId", "VehiclesId");
            return View();
        }

        // POST: Claims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimId,Description,Status,Date,VehicleId")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclesId", "VehiclesId", claim.VehicleId);
            return View(claim);
        }

        // GET: Claims/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Claims == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclesId", "VehiclesId", claim.VehicleId);
            return View(claim);
        }

        // POST: Claims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ClaimId,Description,Status,Date,VehicleId")] Claim claim)
        {
            if (id != claim.ClaimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimExists(claim.ClaimId))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclesId", "VehiclesId", claim.VehicleId);
            return View(claim);
        }

        // GET: Claims/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Claims == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.Vehicle)
                .FirstOrDefaultAsync(m => m.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Claims == null)
            {
                return Problem("Entity set 'benjaminGarridoDatabaseContext.Claims'  is null.");
            }
            var claim = await _context.Claims.FindAsync(id);
            if (claim != null)
            {
                _context.Claims.Remove(claim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimExists(decimal id)
        {
          return _context.Claims.Any(e => e.ClaimId == id);
        }
    }
}
