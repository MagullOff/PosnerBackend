using PosnerBackend.Model;

namespace PosnerBackend.Controllers.Model;

public sealed class PostGameResultResponse
{
    public required List<Attempt> Attempts { get; set; }
    public required int ClueInformationLevel { get; set; }
}