using System.ComponentModel.DataAnnotations;

namespace RaceResultsApi.Models;

public class Jockey
{
    [Key]
    public int JockeyId { get; set; }
    public string Name { get; set; }
}