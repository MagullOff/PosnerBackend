using System.Text.Json;
using PosnerBackend.Controllers.Model;
using PosnerBackend.Model;

namespace PosnerBackend.Repositories;

public sealed class GameResultRepository(ApplicationContext context) : BaseRepository(context)
{
    public ComputingGameResult PostGameResult(PostGameResultResponse response)
    {
        var newResult = new GameResultEntity
        {
            Id = Guid.NewGuid(),
            AttemptsJson = JsonSerializer.Serialize(response.Attempts),
            AverageSpeed = response.Attempts.Where(a =>
                    // ReSharper disable once NullableWarningSuppressionIsUsed
                    a is { IsCueValid: false, ReactionSpeed: not null, AttemptResult: AttemptResult.Correct }).Select(a => (double)a.ReactionSpeed!)
                .Average(),
            ClueInformationLevel = response.ClueInformationLevel
        };
        Context.GameResults.Add(newResult);
        SaveChanges();
        return ComputingGameResult.FromEntity(newResult);
    }

    public List<ComputingGameResult> GetAll()
    {
        return Context.GameResults.Select(ComputingGameResult.FromEntity).ToList();
    }

    public List<GameResult> GetAllComplete()
    {
        return Context.GameResults.Select(GameResult.FromEntity).ToList();
    }
}