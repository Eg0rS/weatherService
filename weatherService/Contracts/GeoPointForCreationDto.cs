namespace Contracts;

public class GeoPointForCreationDto
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string PointType { get; set; }
}