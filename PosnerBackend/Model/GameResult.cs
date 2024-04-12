using System.Text.Json;

namespace PosnerBackend.Model;

public sealed class GameResult
{
    public required Guid Id { get; set; }
    public required int ClueInformationLevel { get; set; }
    public required double AverageSpeed { get; set; }
    public required List<Attempt> Attempts { get; set; }

    public static GameResult FromEntity(GameResultEntity entity)
    {
        var attempts = JsonSerializer.Deserialize<List<Attempt>>(entity.AttemptsJson);
        
        if (attempts == null)
        {
            throw new InvalidOperationException();
        }
        
        return new GameResult
        {
            Attempts = attempts,
            Id = entity.Id,
            AverageSpeed = entity.AverageSpeed,
            ClueInformationLevel = entity.ClueInformationLevel
        };
    }
}