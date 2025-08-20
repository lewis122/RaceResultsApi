using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceResultsApi.Data;
using RaceResultsApi.Models;

namespace RaceResultsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultsController : ControllerBase
{
    private readonly RaceDbContext _db;

    public ResultsController(RaceDbContext db)
    {
        _db = db;
    }

    // GET: results
    [HttpGet]
    public async Task<ActionResult<List<RaceResult>>> GetAllResults()
    {
        return await _db.RaceResults.OrderBy(h => h.RaceId).ToListAsync();
    }

    // GET: results/5/
    [HttpGet("{raceId}")]
    public async Task<ActionResult<IEnumerable<RaceResult>>> GetResults(int raceId)
    {
        var results = await _db.RaceResults
            .Where(r => r.RaceId== raceId)
            .Include(r => r.Jockey)
            .Include(r => r.Race)
            .Include(r => r.Trainer)
            .Include(r => r.Notes)
            .Include(r => r.Horse)
            .ToListAsync();

        if (!results.Any())
        {
            return NotFound();
        }
        
        return results;
    }
}