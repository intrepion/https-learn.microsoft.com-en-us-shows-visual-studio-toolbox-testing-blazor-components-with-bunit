using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorTestingAZ.Data;

namespace BlazorTestingAZ.XUnitTests.Helpers;

internal class DelayedStubWeatherForecastRepo : WeatherForecastRepo
{
    private readonly int forecastsToReturn;

    public DelayedStubWeatherForecastRepo(int forecastsToReturn) => this.forecastsToReturn = forecastsToReturn;

    public override async Task<WeatherForecast[]> GetForecasts()
    {
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        var forecasts = Enumerable
            .Range(1, forecastsToReturn)
            .Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToArray();

        await Task.Delay(50);

        return forecasts;
    }
}
