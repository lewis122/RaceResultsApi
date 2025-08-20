using System.ComponentModel.DataAnnotations;

namespace RaceResultsApi.Models;

public class Trainer
{
    [Key]
    public int TrainerId { get; set; }
    public string Name { get; set; }
}