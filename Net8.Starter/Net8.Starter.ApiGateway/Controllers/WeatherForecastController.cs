using Microsoft.AspNetCore.Mvc;

namespace Net8.Starter.BackEnd.APIGateway.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private static readonly string[] Countries = new[]
		{
			"United States", "Oman", "Japan", "Korea", "China", "Qatar", "Rusia", "Indonesia", "United Kingdom", "Denmark"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)],
				Country = Countries[Random.Shared.Next(Countries.Length)]
			})
			.ToArray();
		}
	}
}
