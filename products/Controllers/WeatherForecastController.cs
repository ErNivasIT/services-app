using Microsoft.AspNetCore.Mvc;

namespace products.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Book", "Table", "Pen"
    };

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/")]
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
     [Route("/{Id}")]
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
