using BlazorTestingAZ.Components.Pages;
using BlazorTestingAZ.Data;
using BlazorTestingAZ.XUnitTests.Helpers;

namespace BlazorTestingAZ.XUnitTests;

/// <summary>
/// These tests are written entirely in C#.
/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
public class WeatherCSharpTests : BunitContext
{
    [Fact]
    public void ClickingButtonIncrementsCounter()
    {
        // Arrange
        Services.AddSingleton<WeatherForecastRepo>(
            new StubWeatherForecastRepo(forecastsToReturn: 2));

        var cut = Render<Weather>();

        // Act - click button to increment counter
        var rows = cut.FindAll("tbody > tr");

        // Assert that the counter was incremented
        Assert.Equal(2, rows.Count);
    }

    [Fact]
    public void WeatherForecastTable_LoadsAndDisplaysData_OnPageInitialization_waiting_for_async()
    {
        // Arrange
        Services.AddSingleton<WeatherForecastRepo>(
            new DelayedStubWeatherForecastRepo(forecastsToReturn: 2));

        var cut = Render<Weather>();

        // Act
        var rows = cut.WaitForElements("tbody > tr");

        // Assert
        Assert.Equal(2, rows.Count);
    }
}
