using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceResultsApi.Data;
using RaceResultsApi.Models;

namespace RaceResultsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HorsesController : ControllerBase
{
    private readonly RaceDbContext _db;
    private readonly ILogger<HorsesController> _logger;

    public HorsesController(RaceDbContext db, ILogger<HorsesController> logger)
    {
        _db = db;
        _logger = logger;
    }

    // GET: horses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Horse>>> GetHorses()
    {
        return await _db.Horses.OrderBy(h => h.Name).ToListAsync();
    }

    // GET: horses/5/results
    [HttpGet("{id}/results")]
    public async Task<ActionResult<IEnumerable<RaceResult>>> GetResultsForHorse(int id)
    {
        var results = await _db.RaceResults
            .Where(r => r.HorseId == id)
            .Include(r => r.Jockey)
            .Include(r => r.Race)
            .Include(r => r.Trainer)
            .Include(r => r.Notes)
            .ToListAsync();

        if (!results.Any())
            return NotFound();

        return results;
    }
}