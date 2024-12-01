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
    public class MediaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MediaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Media
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaModel>>> GetMedia()
        {
            return await _context.Media.ToListAsync();
        }

        // GET: api/Media/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaModel>> GetMediaById(int id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            return media;
        }

        // POST: api/Media
        [HttpPost]
        public async Task<ActionResult<MediaModel>> CreateMedia(MediaModel media)
        {
            media.CreatedAt = DateTime.UtcNow;
            _context.Media.Add(media);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMediaById), new { id = media.MediaID }, media);
        }

        // PUT: api/Media/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedia(int id, MediaModel media)
        {
            if (id != media.MediaID)
            {
                return BadRequest();
            }

            _context.Entry(media).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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

        // DELETE: api/Media/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(int id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            _context.Media.Remove(media);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaExists(int id)
        {
            return _context.Media.Any(e => e.MediaID == id);
        }
    }
}
