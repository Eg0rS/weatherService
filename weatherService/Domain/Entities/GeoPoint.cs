using System;

namespace Domain.Entities;

public class GeoPoint
{
    public Guid Id { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string PointType { get; set; }
    public DateTime DateAdded { get; set; }
    public Guid UserId { get; set; }
}