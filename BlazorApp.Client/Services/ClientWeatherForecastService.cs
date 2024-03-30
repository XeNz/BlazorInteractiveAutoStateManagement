using System.Net.Http.Json;
using Shared;

internal sealed class ClientWeatherForecastService(HttpClient httpClient) : IWeatherForecastService
{
    public IAsyncEnumerable<WeatherForecast> GetAllAsync() =>
        httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/api/weather")!;
}