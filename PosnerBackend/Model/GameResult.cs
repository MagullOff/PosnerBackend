using System.Text.Json;

namespace PosnerBackend.Model;

public sealed class GameResult
{
    public required Guid Id { get; set; }
    public required int ClueInformationLevel { get; set; }
    public required double? AverageSpeedFakeInformation { get; set; }
    public required double? AverageSpeedRealInformation { get; set; }
    public required double? AverageSpeed { get; set; }
    public required int FakeAmount { get; set; }
    public required int RealAmount { get; set; }
    public required int IncorrectFakeAmount { get; set; }
    public required int IncorrectRealAmount { get; set; }
    public required int InvalidAttemptsAmount { get; set; }

    public static GameResult FromEntity(GameResultEntity entity)
    {
        var attempts = JsonSerializer.Deserialize<List<Attempt>>(entity.AttemptsJson);
        
        if (attempts == null)
        {
            throw new InvalidOperationException();
        }
        
        return new GameResult
        {
            Id = entity.Id,
            AverageSpeed = attempts.Where(a => a.AttemptResult != AttemptResult.Timeout && a.ReactionSpeed is > 100 and < 500 ).Select(a => a.ReactionSpeed!).Average(),
            AverageSpeedFakeInformation = attempts.Where(a => a.AttemptResult != AttemptResult.Timeout && a is { IsCueValid: false, ReactionSpeed: > 100 and < 500 }).Select(a => a.ReactionSpeed!).Average(),
            AverageSpeedRealInformation = attempts.Where(a => a.AttemptResult != AttemptResult.Timeout && a is { IsCueValid: true, ReactionSpeed: > 100 and < 500 }).Select(a => a.ReactionSpeed!).Average(),
            FakeAmount = attempts.Count(a => a is { IsCueValid: false }),
            RealAmount = attempts.Count(a => a is { IsCueValid: true }),
            IncorrectFakeAmount = attempts.Count(a => a is { AttemptResult: AttemptResult.Incorrect, IsCueValid: false }),
            IncorrectRealAmount = attempts.Count(a => a is { AttemptResult: AttemptResult.Incorrect, IsCueValid: true }),
            InvalidAttemptsAmount = attempts.Count(a => a is { AttemptResult: AttemptResult.Timeout, ReactionSpeed: not null } || a.ReactionSpeed is > 500),
            ClueInformationLevel = entity.ClueInformationLevel
        };
    }
}