using Microsoft.AspNetCore.Mvc;
using OHD_API.Services;
using OHD_API.Models;
using Microsoft.EntityFrameworkCore;
namespace OHD_API.Controllers
{
    [ApiController]
    [Route("status")]
    public class StatusController : Controller
    {
        private readonly ApplicationDBContext _context;

        public StatusController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(StatusModel statusModel)
        {
            _context.statusModels.Add(statusModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new {id = statusModel.StatusID});
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var status = await _context.statusModels.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _context.statusModels.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            _context.Remove(status);
            _context.SaveChanges();
            return Ok(status);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StatusModel statusModel)
        {
            if (id != statusModel.StatusID)
            {
                return BadRequest();
            }
            _context.Entry(statusModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
