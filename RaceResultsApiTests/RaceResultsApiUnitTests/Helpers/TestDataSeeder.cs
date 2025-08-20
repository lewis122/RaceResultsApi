using RaceResultsApi.Data;
using RaceResultsApi.Models;

namespace RaceResultsApiTests.RaceResultsApiUnitTests.Helpers;

public static class TestDataSeeder
{
    public static void SeedTestData(RaceDbContext context)
    {
        // Only seed once per context instance
        if (context.Horses.Any()) return;

        var horse = new Horse { Name = "Test Horse", HorseId = 1};
        var jockey = new Jockey { Name = "Test Jockey" };
        var trainer = new Trainer { Name = "Test Trainer" };
        var race = new Race { Racecourse = "Test Race", RaceDate = DateTime.Now };

        context.Horses.Add(horse);
        context.Jockeys.Add(jockey);
        context.Trainers.Add(trainer);
        context.Races.Add(race);
        context.SaveChanges();

        var raceResult = new RaceResult
        {
            RaceId = race.RaceId,
            Race = race,
            HorseId = horse.HorseId,
            Horse = horse.Name,
            JockeyId = jockey.JockeyId,
            Jockey = jockey.Name,
            TrainerId = trainer.TrainerId,
            Trainer = trainer,
            FinishingPosition = 1
        };

        context.RaceResults.Add(raceResult);
        context.SaveChanges();
    }
}