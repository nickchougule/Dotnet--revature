namespace WeatherApp;

public class WeatherReporter
{
    private readonly IWeatherService _weatherService;

    public WeatherReporter(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public int GetTemperatureCount(string city)
    {
        var temps = _weatherService.GetTemperature(city);
        return temps.Count;
    }
}