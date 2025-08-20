using System.ComponentModel.DataAnnotations;

namespace RaceResultsApi.Models;

public partial class RaceNote
{
    [Key] 
    public int NoteId { get; set; }

    public int RaceResultId { get; set; }
    public string NoteText { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public RaceResult RaceResult { get; set; }
}