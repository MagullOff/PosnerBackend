using Microsoft.AspNetCore.Mvc;
using PosnerBackend.Controllers.Model;
using PosnerBackend.Model;
using PosnerBackend.Repositories;

namespace PosnerBackend.Controllers;

[ApiController]
[Route("/game")]
public class GameController(GameResultRepository repository) : ControllerBase
{
    [HttpDelete("drop")]
    public ActionResult DropGameBase()
    {
        repository.DropGameResults();
        return Ok();
    }
    
    [HttpPost]
    public ActionResult<ComputingGameResult> PostGameResult(PostGameResultResponse response)
    {
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