using Microsoft.AspNetCore.Mvc;
using StandardDeviationWebAPI.Models;

namespace StandardDeviationWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StandardDeviationController : ControllerBase
    {
        [HttpPost]
        public IActionResult CalculateStandardDeviation([FromBody] PointsList request)
        {
            if (request.Points == null || request.Points.Count == 0)
            {
                return BadRequest("Data list is empty or null.");
            }

            double standardDeviation = CalculateStandardDeviation(request.Points);
            return Ok(new { StandardDeviation = standardDeviation });
        }

        private double CalculateStandardDeviation(List<double> points)
        {
            double mean = points.Average();
            double sumOfSquares = points.Sum(x => Math.Pow(x - mean, 2));
            double variance = sumOfSquares / points.Count;
            return Math.Sqrt(variance);
        }
    }
}
