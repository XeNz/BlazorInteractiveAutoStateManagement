using Shared;

namespace BlazorApp.Services;

internal class WeatherForecastService : IWeatherForecastService
{
    private readonly static DateOnly StartDate = DateOnly.FromDateTime(DateTime.Now);

    private readonly static string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly List<WeatherForecast> _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = StartDate.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    }).ToList();

    public async IAsyncEnumerable<WeatherForecast> GetAllAsync()
    {
        await Task.Delay(300);
        await foreach (var weatherForecast in _forecasts.ToAsyncEnumerable())
        {
            await Task.Delay(50);
            yield return weatherForecast;
        }
    }

}