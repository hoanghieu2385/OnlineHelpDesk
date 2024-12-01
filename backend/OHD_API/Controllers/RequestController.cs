using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OHD_API.Models;
using OHD_API.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OHD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RequestController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestModel>>> GetRequests()
        {
            return await _context.Requests
                .Include(r => r.Media)   // media
                .ToListAsync();
        }

        // GET: api/Requests/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestModel>> GetRequest(int id)
        {
            var request = await _context.Requests
                .Include(r => r.Media)   // media
                .FirstOrDefaultAsync(r => r.RequestID == id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<RequestModel>> CreateRequest(RequestModel request)
        {
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;

            _context.Requests.Add(request);

            // Optionally add media if provided
            if (request.Media != null && request.Media.Any())
            {
                foreach (var media in request.Media)
                {
                    media.RequestID = request.RequestID; // Link media to request
                    media.CreatedAt = DateTime.UtcNow;
                }

                _context.Media.AddRange(request.Media);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRequest), new { id = request.RequestID }, request);
        }

        // PUT: api/Request/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, RequestModel request)
        {
            if (id != request.RequestID)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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
        // DELETE: api/Requests/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests
                .Include(r => r.Media)  // media
                .FirstOrDefaultAsync(r => r.RequestID == id);

            if (request == null)
            {
                return NotFound();
            }

            // Remove associated media
            _context.Media.RemoveRange(request.Media);

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestID == id);
        }
    }
}
