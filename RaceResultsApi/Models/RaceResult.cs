using System.ComponentModel.DataAnnotations;

namespace RaceResultsApi.Models;

public class RaceResult
{
    [Key]
    public int RaceResultId { get; set; }

    public int RaceId { get; set; }
    public int HorseId { get; set; }
    public int JockeyId { get; set; }
    public int TrainerId { get; set; }
    public int FinishingPosition { get; set; }
    public decimal? DistanceBeaten { get; set; }
    public decimal? TimeBeaten { get; set; }
    public string Horse { get; set; }
    public string Jockey { get; set; }
    public Trainer Trainer { get; set; }
    public Race Race { get; set; }
    public ICollection<RaceNote> Notes { get; set; }
}