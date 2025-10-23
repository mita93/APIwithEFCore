using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApp.Data;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaintenanceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/maintenance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetAll()
        {
            return await _context.Maintenances
                .Include(m => m.Settings)
                    .ThenInclude(s => s.Items)
                        .ThenInclude(i => i.DataVariants)
                .ToListAsync();
        }

        // GET: api/maintenance/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Maintenance>> Get(int id)
        {
            var maintenance = await _context.Maintenances
                .Include(m => m.Settings)
                    .ThenInclude(s => s.Items)
                        .ThenInclude(i => i.DataVariants)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (maintenance == null)
                return NotFound();

            return maintenance;
        }

        // POST: api/maintenance
        [HttpPost]
        public async Task<ActionResult<Maintenance>> Post(Maintenance maintenance)
        {
            _context.Maintenances.Add(maintenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = maintenance.Id }, maintenance);
        }

        // PUT: api/maintenance/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Maintenance maintenance)
        {
            if (id != maintenance.Id)
                return BadRequest();

            _context.Entry(maintenance).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/maintenance/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var maintenance = await _context.Maintenances.FindAsync(id);
            if (maintenance == null)
                return NotFound();

            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
