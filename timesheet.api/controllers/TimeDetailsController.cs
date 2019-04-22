using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using timesheet.data;
using timesheet.model;

namespace timesheet.api.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeDetailsController : ControllerBase
    {
        private readonly TimesheetDb _context;

        public TimeDetailsController(TimesheetDb context)
        {
            _context = context;
        }

        // GET: api/TimeDetails
        [HttpGet]
        public IEnumerable<TimeDetails> GetTimeDetails()
        {
            return _context.TimeDetails;
        }

        // GET: api/TimeDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeDetails = await _context.TimeDetails.FindAsync(id);

            if (timeDetails == null)
            {
                return NotFound();
            }

            return Ok(timeDetails);
        }

        // PUT: api/TimeDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeDetails([FromRoute] int id, [FromBody] TimeDetails timeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeDetailsExists(id))
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

        // POST: api/TimeDetails
        [HttpPost]
        public async Task<IActionResult> PostTimeDetails([FromBody] TimeDetails timeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TimeDetails.Add(timeDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeDetails", new { id = timeDetails.Id }, timeDetails);
        }

        // DELETE: api/TimeDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeDetails = await _context.TimeDetails.FindAsync(id);
            if (timeDetails == null)
            {
                return NotFound();
            }

            _context.TimeDetails.Remove(timeDetails);
            await _context.SaveChangesAsync();

            return Ok(timeDetails);
        }

        private bool TimeDetailsExists(int id)
        {
            return _context.TimeDetails.Any(e => e.Id == id);
        }
    }
}