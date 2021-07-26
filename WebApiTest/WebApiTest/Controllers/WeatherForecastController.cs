using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Service;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiceRequest _serviceRequest;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IServiceRequest serviceRequest)
        {
            _serviceRequest = serviceRequest;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = await _serviceRequest.GetDeckOfCards(1);
            var resp1 = await _serviceRequest.PostDeckOfCards(1);

            return Ok(resp1);
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
