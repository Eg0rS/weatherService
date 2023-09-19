using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Abstractions;

public interface IWeatherForecastRepository
{
    Task<WeatherForecast> GetByGeoPointIdAsync(GeoPoint geoPoint);
}