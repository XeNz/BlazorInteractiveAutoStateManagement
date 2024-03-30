using BlazorApp.Client.Pages;
using BlazorApp.Components;
using BlazorApp.Services;
using Shared;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.MapGet("/api/weather", (IWeatherForecastService weatherService) => weatherService.GetAllAsync());

app.Run();