using Microsoft.AspNetCore.Mvc;
using OHD_API.Services;
using OHD_API.Models;
using Microsoft.EntityFrameworkCore;
namespace OHD_API.Controllers
{
    [ApiController]
    [Route("mediaType")]
    public class MediaTypeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MediaTypeController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MediaTypeModel mediaTypeModel)
        {
            _context.MediaTypes.Add(mediaTypeModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = mediaTypeModel.MediaTypeID });
        }
        [HttpGet]
        public ActionResult<IEnumerable<MediaTypeModel>> Get()
        {
            var media = _context.MediaTypes.ToList();
            if (media == null)
            {
                return NotFound();
            }
            return Ok(media);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var status = await _context.MediaTypes.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var media = await _context.MediaTypes.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            _context.Remove(media);
            _context.SaveChanges();
            return Ok(media);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MediaTypeModel mediaModel)
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