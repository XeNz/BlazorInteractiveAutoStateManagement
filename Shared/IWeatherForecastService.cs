namespace Shared;

public interface IWeatherForecastService
{
    IAsyncEnumerable<WeatherForecast> GetAllAsync();
}