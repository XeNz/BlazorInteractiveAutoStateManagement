using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
builder.Services.AddSingleton<IWeatherForecastService, ClientWeatherForecastService>();


await builder.Build().RunAsync();