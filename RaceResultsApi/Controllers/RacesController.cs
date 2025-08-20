using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceResultsApi.Data;
using RaceResultsApi.Models;

namespace RaceResultsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RacesController : ControllerBase
{
    private readonly RaceDbContext _db;

    public RacesController(RaceDbContext db)
    {
        _db = db;
    }

    // GET: races
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
    {
        return await _db.Races.OrderBy(h => h.RaceDate).ToListAsync();
    }
}