namespace Contracts;

public class WeatherForecastDto
{
    public WeatherForecastDto(string summaries)
    {
        Summaries = summaries;
    }

    public string Summaries { get; set; }
    public int TemperatureC { get; set; }
}