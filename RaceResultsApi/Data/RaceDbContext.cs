using Microsoft.EntityFrameworkCore;
using RaceResultsApi.Models;

namespace RaceResultsApi.Data
{
    public class RaceDbContext : DbContext
    {
        public RaceDbContext(DbContextOptions<RaceDbContext> options) : base(options) { }

        public DbSet<Horse> Horses { get; set; }
        public DbSet<Jockey> Jockeys { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<RaceNote> RaceNotes { get; set; }
    }
}