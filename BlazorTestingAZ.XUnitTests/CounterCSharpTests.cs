﻿using BlazorTestingAZ.Components.Pages;

namespace BlazorTestingAZ.XUnitTests;

/// <summary>
/// These tests are written entirely in C#.
/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
public class CounterCSharpTests : BunitContext
{
    [Fact]
    public void CounterStartsAtZero()
    {
        // Arrange
        var cut = Render<Counter>();

        // Assert that content of the paragraph shows counter at zero
        cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 0</p>");
    }

    [Fact]
    public void ClickingButtonIncrementsCounter()
    {
        // Arrange
        var cut = Render<Counter>();

        // Act - click button to increment counter
        cut.Find("button").Click();

        // Assert that the counter was incremented
        cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
    }

    [Fact]
    public void Count_Increments_WhenButtonIsClicked()
    {
        // Arrange
        var cut = Render<Counter>();

        // Act
        // Role based lookup coming to bUnit soon. Active
        // worked on by Scott Sauber
        cut.Find("button").Click();

        // Assert
        var statusText = cut.Find("[role=status]").TextContent;
        Assert.Equal("Current count: 1", statusText);
    }
}
