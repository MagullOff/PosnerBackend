using Microsoft.AspNetCore.Mvc;
using PosnerBackend.Controllers.Model;
using PosnerBackend.Model;
using PosnerBackend.Repositories;

namespace PosnerBackend.Controllers;

[ApiController]
[Route("/game")]
public class GameController(GameResultRepository repository) : ControllerBase
{
    [HttpPost]
    public ActionResult<ComputingGameResult> PostGameResult(PostGameResultResponse response)
    {
        if (response.Attempts.Where(a => !a.IsCueValid).All(a => a.AttemptResult != AttemptResult.Correct))
        {
            return NoContent();
        }
        try
        {
            var result = repository.PostGameResult(response);
            return new OkObjectResult(result);
        }
        catch (InvalidOperationException)
        {
            return BadRequest();
        }
    }
}