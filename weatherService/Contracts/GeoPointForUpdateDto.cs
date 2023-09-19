namespace Contracts;

public class GeoPointForUpdateDto
{
    public GeoPointForUpdateDto(string pointType)
    {
        PointType = pointType;
    }

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string PointType { get; set; }
}