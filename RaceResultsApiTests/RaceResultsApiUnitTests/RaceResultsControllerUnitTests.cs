using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RaceResultsApi.Controllers;
using RaceResultsApi.Data;
using RaceResultsApi.Models;
using RaceResultsApiTests.RaceResultsApiUnitTests.Helpers;

namespace RaceResultsApiTests.RaceResultsApiUnitTests;

public class ResultsControllerTests
{
    private RaceDbContext GetInMemoryDbContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<RaceDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new RaceDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    [Fact]
    public async Task GetAllResults_ReturnsAllRaceResults()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedTestData(context);
        var controller = new ResultsController(context);

        // Act
        var result = await controller.GetAllResults();

        // Assert
        var results = Assert.IsType<List<RaceResult>>(result.Value);
        Assert.Single(results);
        Assert.Equal("Test Horse", results[0].Horse);
    }
}
