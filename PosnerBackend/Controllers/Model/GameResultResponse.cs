using PosnerBackend.Model;

namespace PosnerBackend.Controllers.Model;

public sealed class GameResultResponse
{
    public required int ClueInformationLevel { get; set; }
    public required double AverageSpeed { get; set; }

    public static GameResultResponse FromComputingGameResult(ComputingGameResult result)
    {
        return new GameResultResponse
            { AverageSpeed = result.AverageSpeed, ClueInformationLevel = result.ClueInformationLevel };
    }
}