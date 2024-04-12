using PosnerBackend.Model;

namespace PosnerBackend.Controllers.Model;

public sealed class StatsResponse
{
    public required List<GameResultResponse> GameResults { get; set; }
    public required double PearsonCorrelation { get; set; }
    public required double LinearA { get; set; }
    public required double LinearB { get; set; }
}