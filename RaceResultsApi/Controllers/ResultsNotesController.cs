using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceResultsApi.Data;
using RaceResultsApi.Models;

namespace RaceResultsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultsNotesController : ControllerBase
    {
        private readonly RaceDbContext _db;

        public ResultsNotesController(RaceDbContext db)
        {
            _db = db;
        }

        // GET: results_notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RaceNote>>> GetNotesForResult(int id)
        {
            var notes = await _db.RaceNotes
                .Where(n => n.RaceResultId == id)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notes;
        }

        // POST: results_notes/5
        [HttpPost("{id}")]
        public async Task<ActionResult<RaceNote>> AddNoteToResult(int id, [FromBody] RaceNote note)
        {
            if (string.IsNullOrWhiteSpace(note.NoteText))
                return BadRequest("Note text cannot be empty.");

            note.RaceResultId = id;
            note.CreatedAt = DateTime.UtcNow;

            _db.RaceNotes.Add(note);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNotesForResult), new { id = id }, note);
        }
    }
}