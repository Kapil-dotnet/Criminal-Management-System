using CriminalManagementSystem.Data;
using CriminalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CriminalManagementSystem.Controllers
{
    [Authorize]
    [Route("api/criminals")]
    [ApiController]
    public class CriminalsApiController : ControllerBase
    {
        private readonly CriminalDbContext _context;

        public CriminalsApiController(CriminalDbContext context)
        {
            _context = context;
        }

        // Sabhi criminals ki list: GET /api/criminals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Criminal>>> GetCriminals()
        {
            var criminals = await _context.Criminals
                .AsNoTracking()
                .ToListAsync();

            return Ok(criminals);
        }

        // ID se ek criminal: GET /api/criminals/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Criminal>> GetCriminal(int id)
        {
            var criminal = await _context.Criminals
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CriminalId == id);

            if (criminal == null)
            {
                return NotFound();
            }

            return Ok(criminal);
        }
        // POST: api/criminals
        [HttpPost]
        public async Task<ActionResult<Criminal>> PostCriminal(Criminal criminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Criminals.Add(criminal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCriminal),
                new { id = criminal.CriminalId },
                criminal);
        }
        // PUT: api/criminals/8
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriminal(int id, Criminal criminal)
        {
            if (id != criminal.CriminalId)
            {
                return BadRequest("URL ki ID aur record ki ID match nahi karti.");
            }

            var exists = await _context.Criminals
                .AnyAsync(c => c.CriminalId == id);

            if (!exists)
            {
                return NotFound();
            }

            _context.Entry(criminal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/criminals/8
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriminal(int id)
        {
            var criminal = await _context.Criminals.FindAsync(id);

            if (criminal == null)
            {
                return NotFound();
            }

            _context.Criminals.Remove(criminal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}