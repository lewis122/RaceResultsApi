using System.ComponentModel.DataAnnotations;

namespace RaceResultsApi.Models;

public class Horse
{
    [Key]
    public int HorseId { get; set; }
    public string Name { get; set; }
}