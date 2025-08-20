using System.ComponentModel.DataAnnotations;

namespace RaceResultsApi.Models;

public class Race
{
    [Key]
    public int RaceId { get; set; }
    public DateTime RaceDate { get; set; }
    public TimeSpan RaceTime { get; set; }
    public string Racecourse { get; set; }
    public decimal RaceDistance { get; set; }
    public ICollection<RaceResult> Results { get; set; }
}