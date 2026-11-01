using CriminalManagementSystem.Data;
using CriminalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CriminalManagementSystem.Controllers
{
    [Authorize]
    public class CriminalsController : Controller
    {
        private readonly CriminalDbContext _context;

        public CriminalsController(CriminalDbContext context)
        {
            _context = context;
        }

        // GET: Criminals
        public async Task<IActionResult> Index(string searchString, string status)
        {
            var criminals = _context.Criminals.AsQueryable();

            // Search by Criminal Code, First Name, Last Name or City
            if (!string.IsNullOrEmpty(searchString))
            {
                criminals = criminals.Where(c =>
                    c.CriminalCode.Contains(searchString) ||
                    c.FirstName.Contains(searchString) ||
                    c.LastName.Contains(searchString) ||
                    c.City.Contains(searchString));
            }

            // Filter by Status
            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                criminals = criminals.Where(c => c.Status == status);
            }

            ViewBag.SearchString = searchString;
            ViewBag.Status = status;

            return View(await criminals.ToListAsync());
        }

        // GET: Criminals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminal = await _context.Criminals
                .FirstOrDefaultAsync(m => m.CriminalId == id);

            if (criminal == null)
            {
                return NotFound();
            }

            return View(criminal);
        }

        // GET: Criminals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Criminals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("CriminalId,CriminalCode,FirstName,LastName,Gender,DateOfBirth,Age,Phone,Email,Address,City,State,IdentificationMark,Photo,Status,ArrestDate,ReleaseDate,CreatedDate")]
            Criminal criminal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criminal);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(criminal);
        }

        // GET: Criminals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminal = await _context.Criminals.FindAsync(id);

            if (criminal == null)
            {
                return NotFound();
            }

            return View(criminal);
        }

        // POST: Criminals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("CriminalId,CriminalCode,FirstName,LastName,Gender,DateOfBirth,Age,Phone,Email,Address,City,State,IdentificationMark,Photo,Status,ArrestDate,ReleaseDate,CreatedDate")]
            Criminal criminal)
        {
            if (id != criminal.CriminalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criminal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriminalExists(criminal.CriminalId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(criminal);
        }

        // GET: Criminals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminal = await _context.Criminals
                .FirstOrDefaultAsync(m => m.CriminalId == id);

            if (criminal == null)
            {
                return NotFound();
            }

            return View(criminal);
        }

        // POST: Criminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var criminal = await _context.Criminals.FindAsync(id);

            if (criminal != null)
            {
                _context.Criminals.Remove(criminal);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CriminalExists(int id)
        {
            return _context.Criminals.Any(e => e.CriminalId == id);
        }
    }
}