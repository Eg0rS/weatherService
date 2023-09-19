using System.Text;
using System.Text.Json;
using Domain.Entities;
using Repository.Abstractions;

namespace Repository;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private const string BaseUrl = "http://calculator";
    private const string Url = $"{BaseUrl}/weather";

    public async Task<WeatherForecast> GetByGeoPointIdAsync(GeoPoint geoPoint)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, Url);
        request.Content = new StringContent(JsonSerializer.Serialize(geoPoint), Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(content);
        return weatherForecast;
    }
}