using AzureTaskTracker.Data;
using AzureTaskTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureTaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TasksController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _db.Tasks.OrderByDescending(t => t.Id).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskItem input)
        {
            if (string.IsNullOrWhiteSpace(input.Title))
                return BadRequest("Title boş olamaz.");

            _db.Tasks.Add(input);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await _db.Tasks.FindAsync(id);
            return t is null ? NotFound() : Ok(t);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskItem updated)
        {
            var t = await _db.Tasks.FindAsync(id);
            if (t is null) return NotFound();

            t.Title = updated.Title;
            t.IsCompleted = updated.IsCompleted;
            await _db.SaveChangesAsync();
            return Ok(t);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await _db.Tasks.FindAsync(id);
            if (t is null) return NotFound();
            _db.Tasks.Remove(t);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
