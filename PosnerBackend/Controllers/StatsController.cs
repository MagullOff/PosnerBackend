using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using Microsoft.AspNetCore.Mvc;
using PosnerBackend.Controllers.Model;
using PosnerBackend.Repositories;

namespace PosnerBackend.Controllers;

[ApiController]
[Route("/stats")]
public class StatsController(GameResultRepository repository) : ControllerBase
{
   [HttpGet]
   public StatsResponse GetStats()
   {
      var games = repository.GetAll().Where(r => r.AverageSpeed is < 500 and > 200).ToList();
      var x = games.Select(g => (double)g.ClueInformationLevel).ToArray();
      var y = games.Select(g => g.AverageSpeed).ToArray();
      var (a, b) = Fit.Line(x, y);
      
      return new StatsResponse
      {
         GameResults = games.Select(GameResultResponse.FromComputingGameResult).ToList(),
         PearsonCorrelation = Correlation.Pearson(x,y),
         LinearA = a,
         LinearB = b
      };
   }
}