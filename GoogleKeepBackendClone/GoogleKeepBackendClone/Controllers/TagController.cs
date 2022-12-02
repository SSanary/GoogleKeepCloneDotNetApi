using GoogleKeepBackendClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoogleKeepBackendClone.Controllers
{
    public class TagController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TagController()
        {
            _context = new DataBaseContext();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            Thread.Sleep(2000);
            return await _context.Tags.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTagByTagID(int id)
        {
            var tag = await _context.Tags.FindAsync(id );

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            _context.Entry(tag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> PostReminder(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReminder", new { id = tag.Id }, tag);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}

