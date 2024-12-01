using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OHD_API.Models;
using OHD_API.Services;
using OHD_API.DTOs;
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
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetRequests()
        {
            var requests = await _context.Requests
                .Include(r => r.Media) // Include Media navigation property
                .ToListAsync();

            // Map RequestModel to RequestDTO
            var requestDtos = requests.Select(r => new RequestDTO
            {
                RequestID = r.RequestID,
                UserID = r.UserID,
                FacilityID = r.FacilityID,
                Description = r.Description,
                Location = r.Location,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt,
                Media = r.Media.Select(m => new MediaDTO
                {
                    MediaID = m.MediaID,
                    MediaTypeID = m.MediaTypeID,
                    FilePath = m.FilePath,
                    MediaSource = m.MediaSource,
                    CreatedAt = m.CreatedAt
                }).ToList()
            }).ToList();

            return Ok(requestDtos);
        }

        // GET: api/Requests/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDTO>> GetRequest(int id)
        {
            var request = await _context.Requests
                .Include(r => r.Media)
                .FirstOrDefaultAsync(r => r.RequestID == id);

            if (request == null)
            {
                return NotFound();
            }

            var requestDto = new RequestDTO
            {
                RequestID = request.RequestID,
                UserID = request.UserID,
                FacilityID = request.FacilityID,
                Description = request.Description,
                Location = request.Location,
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt,
                Media = request.Media.Select(m => new MediaDTO
                {
                    MediaID = m.MediaID,
                    MediaTypeID = m.MediaTypeID,
                    FilePath = m.FilePath,
                    MediaSource = m.MediaSource,
                    CreatedAt = m.CreatedAt
                }).ToList()
            };

            return requestDto;
        }

        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<RequestDTO>> CreateRequest(RequestDTO requestDto)
        {
            var request = new RequestModel
            {
                UserID = requestDto.UserID,
                FacilityID = requestDto.FacilityID,
                Description = requestDto.Description,
                Location = requestDto.Location,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Save the Request
            _context.Requests.Add(request);
            await _context.SaveChangesAsync(); // Generates RequestID

            // Handle Media if provided
            if (requestDto.Media != null && requestDto.Media.Any())
            {
                var mediaEntities = requestDto.Media.Select(m => new MediaModel
                {
                    RequestID = request.RequestID, // Assign the generated RequestID
                    MediaTypeID = m.MediaTypeID,
                    FilePath = m.FilePath,
                    MediaSource = m.MediaSource,
                    CreatedAt = DateTime.UtcNow
                }).ToList();

                _context.Media.AddRange(mediaEntities);
                await _context.SaveChangesAsync();
            }

            // Map RequestModel to RequestDTO for response
            var responseDto = new RequestDTO
            {
                RequestID = request.RequestID,
                UserID = request.UserID,
                FacilityID = request.FacilityID,
                Description = request.Description,
                Location = request.Location,
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt,
                Media = requestDto.Media // Return the same media DTOs from the request
            };

            return CreatedAtAction(nameof(GetRequest), new { id = request.RequestID }, responseDto);
        }

        // PUT: api/Request/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, RequestDTO requestDto)
        {
            // Validate if the Request ID in the URL matches the one in the payload
            if (id != requestDto.RequestID)
            {
                return BadRequest("Request ID mismatch.");
            }

            // Find the existing request in the database
            var existingRequest = await _context.Requests
                .Include(r => r.Media) // Include Media for possible updates
                .FirstOrDefaultAsync(r => r.RequestID == id);

            if (existingRequest == null)
            {
                return NotFound($"Request with ID {id} not found.");
            }

            // Update the existing request with data from the DTO
            existingRequest.UserID = requestDto.UserID;
            existingRequest.FacilityID = requestDto.FacilityID;
            existingRequest.Description = requestDto.Description;
            existingRequest.Location = requestDto.Location;
            existingRequest.UpdatedAt = DateTime.UtcNow;

            // If there are updates to Media, handle them here (optional)
            if (requestDto.Media != null && requestDto.Media.Any())
            {
                // Clear existing Media
                _context.Media.RemoveRange(existingRequest.Media);

                // Add updated Media
                var updatedMedia = requestDto.Media.Select(m => new MediaModel
                {
                    RequestID = id, // Link to the existing request
                    MediaTypeID = m.MediaTypeID,
                    FilePath = m.FilePath,
                    MediaSource = m.MediaSource,
                    CreatedAt = DateTime.UtcNow
                }).ToList();

                _context.Media.AddRange(updatedMedia);
            }

            // Mark the entity as modified and save changes
            _context.Entry(existingRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound($"Request with ID {id} no longer exists.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Successfully updated
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
