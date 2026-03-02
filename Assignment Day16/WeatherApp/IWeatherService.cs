namespace WeatherApp;

public interface IWeatherService
{
    public List<double> GetTemperature(string city)
    {
        return new List<double> { 25, 26, 27 };
    }
}