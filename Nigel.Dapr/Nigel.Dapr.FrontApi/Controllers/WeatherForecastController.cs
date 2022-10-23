using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Nigel.Dapr.FrontApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public readonly IConfiguration _configuration;

        private readonly DaprClient _daprClient;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient, IConfiguration configuration)
        {
            _logger = logger;
            _daprClient = daprClient;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get()
        {
            var s = this._configuration.GetValue<string>("My");
            var s1 = this._configuration.GetValue<string>("My1");
            var result = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "backend", "Backend/WeatherForecast/GetWeatherForecast");
            return Ok(result);
        }

        [HttpGet("GetWeatherForecast2")]
        public IEnumerable<WeatherForecast> Get2()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpPut("SaveRedisState")]
        public async Task<ActionResult> SaveRedisStateAsync(string key,string value)
        {
           await  this._daprClient.SaveStateAsync("demodapr-statestore", key, value);
           return this.Ok(new
           {
               key = key,
               value = value
           });
        }

        [HttpGet("GetRedisState")]
        public async Task<ActionResult> SaveRedisStateAsync(string key)
        {
            var value = await this._daprClient.GetStateAsync<string>("demodapr-statestore", key);
            return this.Ok(new
            {
                key = key,
                value = value
            });
        }
    }
}