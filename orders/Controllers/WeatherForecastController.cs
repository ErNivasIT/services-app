using Microsoft.AspNetCore.Mvc;

namespace orders.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Chai Lao", "Paani Lao", "Chinie Laao", "Garam Hai Kya"
    };

    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger)
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
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet]
    [Route("{Id}")]
    public IEnumerable<WeatherForecast> GetById(int Id)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .Take(Id)
        .ToArray();
    }
}
