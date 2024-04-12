namespace PosnerBackend.Model;

public sealed class ComputingGameResult
{
    public required Guid Id { get; set; }
    public required int ClueInformationLevel { get; set; }
    public required double AverageSpeed { get; set; }

    public static ComputingGameResult FromEntity(GameResultEntity entity)
    {
        return new ComputingGameResult
        {
            Id = entity.Id,
            AverageSpeed = entity.AverageSpeed,
            ClueInformationLevel = entity.ClueInformationLevel
        };
    }
}