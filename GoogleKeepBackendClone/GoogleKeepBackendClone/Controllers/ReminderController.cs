using GoogleKeepBackendClone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace GoogleKeepBackendClone.Controllers
{
    public class ReminderController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ReminderController()
        {
            _context = new DataBaseContext();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reminder>>> GetAllReminder()
        {
            Thread.Sleep(2000);
            return await _context.Reminders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetReminderByReminderID(int id)
        {
            var reminder = await _context.Notes.FindAsync(id);

            if (reminder == null)
            {
                return NotFound();
            }

            return reminder;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminder(int id, Reminder reminder)
        {
            if (id != reminder.Id)
            {
                return BadRequest();
            }

            _context.Entry(reminder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReminderExists(id))
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
        public async Task<ActionResult<Note>> PostReminder(Reminder reminder)
        {
            _context.Reminders.Add(reminder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReminder", new { id = reminder.Id }, reminder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            var reminder = await _context.Reminders.FindAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }

            _context.Reminders.Remove(reminder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReminderExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
