using System;

namespace Contracts;

public class GeoPointDto
{
    public GeoPointDto(Guid id, decimal latitude, decimal longitude, string pointType, DateTime dateAdded, Guid userId, WeatherForecastDto weatherForecast)
    {
        Id = id;
        Latitude = latitude;
        Longitude = longitude;
        PointType = pointType;
        DateAdded = dateAdded;
        UserId = userId;
        WeatherForecast = weatherForecast;
    }

    public Guid Id { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string PointType { get; set; }
    public DateTime DateAdded { get; set; }
    public Guid UserId { get; set; }
    public WeatherForecastDto WeatherForecast { get; set; }
}