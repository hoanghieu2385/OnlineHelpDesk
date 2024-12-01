using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OHD_API.Models;
using OHD_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OHD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public FacilityController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Facility
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityModel>>> GetFacilities()
        {
            return await _context.Facilities.ToListAsync();
        }

        // GET: api/Facility/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityModel>> GetFacility(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
        }

        // POST: api/Facility
        [HttpPost]
        public async Task<ActionResult<FacilityModel>> CreateFacility(FacilityModel facility)
        {
            facility.CreatedAt = DateTime.UtcNow;
            facility.UpdatedAt = DateTime.UtcNow;

            _context.Facilities.Add(facility);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacility), new { id = facility.FacilityID }, facility);
        }

        // PUT: api/Facility/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFacility(int id, FacilityModel facility)
        {
            if (id != facility.FacilityID)
            {
                return BadRequest();
            }

            var existingFacility = await _context.Facilities.FindAsync(id);
            if (existingFacility == null)
            {
                return NotFound();
            }

            existingFacility.FacilityName = facility.FacilityName;
            existingFacility.FacilityLocation = facility.FacilityLocation;
            existingFacility.Facility_head_ID = facility.Facility_head_ID;
            existingFacility.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(id))
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

        // DELETE: api/Facility/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }

            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacilityExists(int id)
        {
            return _context.Facilities.Any(e => e.FacilityID == id);
        }
    }
}
