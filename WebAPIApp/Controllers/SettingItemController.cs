using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApp.Data;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/maintenance/[controller]")]
    public class SettingItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SettingItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/maintenance/settingitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SettingItem>> GetSettingItem(int id)
        {
            var item = await _context.SettingItems
                .Include(i => i.DataVariants)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return NotFound();

            return item;
        }

        // PATCH: api/maintenance/settingitem/5
        // → 部分更新（例: itemData だけ変更）
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSettingItem(int id, [FromBody] JsonPatchDocument<SettingItem> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var item = await _context.SettingItems
                .Include(i => i.DataVariants)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return NotFound();

            patchDoc.ApplyTo(item, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/maintenance/settingitem
        [HttpPost]
        public async Task<ActionResult<SettingItem>> CreateSettingItem(SettingItem item)
        {
            _context.SettingItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSettingItem), new { id = item.Id }, item);
        }

        // DELETE: api/maintenance/settingitem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSettingItem(int id)
        {
            var item = await _context.SettingItems.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.SettingItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
