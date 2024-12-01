using Microsoft.AspNetCore.Mvc;
using OHD_API.Services;
using OHD_API.Models;
using Microsoft.EntityFrameworkCore;
namespace OHD_API.Controllers
{
    [ApiController]
    [Route("media")]
    public class MediaController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MediaController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MediaModel mediaModel)
        {
            _context.mediaModels.Add(mediaModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = mediaModel.MediaTypeID });
        }
        [HttpGet]
        public ActionResult<IEnumerable<MediaModel>> Get()
        {
            var media = _context.mediaModels.ToList();
            if (media == null)
            {
                return NotFound();
            }
            return Ok(media);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var status = await _context.mediaModels.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var media = await _context.mediaModels.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            _context.Remove(media);
            _context.SaveChanges();
            return Ok(media);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MediaModel mediaModel)
        {
            if (id != mediaModel.MediaTypeID)
            {
                return BadRequest();
            }
            _context.Entry(mediaModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}