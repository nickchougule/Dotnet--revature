using Moq;
using WeatherApp;

namespace WeatherApp.Tests;

public class WeatherReporterTests
{
    [Fact]
    public void GetTemperatureCount_ReturnsCorrectCount()
    {
        var mockService = new Mock<IWeatherService>();

        mockService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Returns(new List<double> { 30, 32, 28, 31, 29 });

        var reporter = new WeatherReporter(mockService.Object);

        var count = reporter.GetTemperatureCount("New York");

        Assert.Equal(5, count);
    }

    [Fact]
    public void GetTemperatureCount_ThrowsException_WhenServiceFails()
    {
        var mockService = new Mock<IWeatherService>();

        mockService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Throws(new Exception("City not found"));

        var reporter = new WeatherReporter(mockService.Object);

        Assert.Throws<Exception>(() =>
            reporter.GetTemperatureCount("Unknown"));
    }
}